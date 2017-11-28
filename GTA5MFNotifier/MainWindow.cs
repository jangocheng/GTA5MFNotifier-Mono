using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using GTA5MFNotifier;
using Gtk;
using Microsoft.Win32;
using Newtonsoft.Json;
using Notifications;
using static JsonClasses;

public partial class MainWindow : Window
{
    const string REGISTRY_KEY_NAME = "GTA5ModsForumsNotifier";
    RegistryKey runSubkey;

    StatusIcon statusIcon;
    TreeStore treeStore;
    CellRendererText categoryRenderer, titleRenderer, bodyRenderer;
    TreeViewColumn columnCategory, columnTitle, columnBody, columnLink;

    internal bool ranOnStartup = false;

    string jsonSettingsFileName;
    uint timeoutTag = 0;

    List<Post> lastRecentPosts = new List<Post>();
    string[] ignoredUsers = { };

    public MainWindow() : base(WindowType.Toplevel)
    {
        Build();

        this.WindowStateEvent += MainWindow_WindowStateEvent;

        treeStore = new TreeStore(typeof(string), typeof(string), typeof(string), typeof(string));

        categoryRenderer = new CellRendererText();
        titleRenderer = new CellRendererText();
        bodyRenderer = new CellRendererText();

        columnCategory = new TreeViewColumn("Category", categoryRenderer) { Resizable = true, Sizing = TreeViewColumnSizing.Fixed, FixedWidth = 200 };
        columnTitle = new TreeViewColumn("Title", titleRenderer) { Resizable = true, Sizing = TreeViewColumnSizing.Fixed, FixedWidth = 200 };
        columnBody = new TreeViewColumn("Body", bodyRenderer) { Resizable = true };
        columnLink = new TreeViewColumn() { Title = "Link", Resizable = true, Visible = false };

        columnCategory.PackStart(categoryRenderer, true);
        columnTitle.PackStart(titleRenderer, true);
        columnBody.PackStart(bodyRenderer, true);

        columnCategory.AddAttribute(categoryRenderer, "text", 0);
        columnTitle.AddAttribute(titleRenderer, "text", 1);
        columnBody.AddAttribute(bodyRenderer, "text", 2);

        tvNotifications.AppendColumn(columnCategory);
        tvNotifications.AppendColumn(columnTitle);
        tvNotifications.AppendColumn(columnBody);
        tvNotifications.AppendColumn(columnLink);

        tvNotifications.Model = treeStore;

        int platform = (int)Environment.OSVersion.Platform;

        if (platform == 4 || platform == 6 || platform == 128) //unix/mac
        {
            cbRunOnStartup.Sensitive = false; //disable running on startup
        }
        else //windows
        {
            runSubkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            object regVal = runSubkey.GetValue(REGISTRY_KEY_NAME);

            //just in case the program is moved to another location
            if (regVal != null && (regVal as string) != Assembly.GetExecutingAssembly().Location + " -startup")
            {
                runSubkey.DeleteValue(REGISTRY_KEY_NAME, false);
                regVal = null;
            }

            cbRunOnStartup.Active = regVal != null;

            //add event handler after change checked value, so that we don't trigger setting the registry value
            cbRunOnStartup.Toggled += cbRunOnStartup_Toggled;
        }

        jsonSettingsFileName = System.IO.Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".json");

        if (File.Exists(jsonSettingsFileName))
        {
            try
            {
                ProgramSettings.JSONSettings settings = null;

                if (ProgramSettings.Load(jsonSettingsFileName, out settings))
                {
                    cbPlayNotificationSound.Active = settings.PlaySound;
                    SetCheckedCategoryCheckboxesFromList(settings.EnabledCategories);
                    cbOnlyNewTopics.Active = settings.OnlyNewTopics;
                    cbTitleContains.Active = settings.OnlyTitleContains;
                    cbBodyContains.Active = settings.OnlyBodyContains;
                    textviewContains.Buffer.Text = settings.Contains;
                    cbIgnoreUsers.Active = settings.IgnoreUsers;
                    tvIgnoreUsers.Buffer.Text = settings.Users;
                    comboboxInterval.Active = settings.IntervalIndex;

                    if (settings.Enabled)
                        cbEnable.Active = settings.Enabled;
                }
            }
            catch { }
        }

        statusIcon = new StatusIcon();
        statusIcon.Pixbuf = Gdk.Pixbuf.LoadFromResource("GTA5MFNotifier.Resources.icon.png");
        statusIcon.Tooltip = "GTA5-Mods Forums Notifier";
        statusIcon.Visible = false;
        statusIcon.Activate += statusIcon_Activate;

        //GTA5MFNotifier.Notification.Initialize();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        var settings = new ProgramSettings.JSONSettings(cbEnable.Active, cbPlayNotificationSound.Active, GenerateListOfEnabledCategories(),
                                                        cbOnlyNewTopics.Active, cbTitleContains.Active, cbBodyContains.Active, textviewContains.Buffer.Text, cbIgnoreUsers.Active, tvIgnoreUsers.Buffer.Text, comboboxInterval.Active);

        try
        {
            ProgramSettings.Save(settings, jsonSettingsFileName);
        }
        catch { }

        Application.Quit();
        a.RetVal = true;
    }

    protected void MainWindow_WindowStateEvent(object o, WindowStateEventArgs args)
    {
        if (args.Event.NewWindowState == Gdk.WindowState.Iconified)
        {
            this.Visible = false;
            statusIcon.Visible = true;
        }
    }

    protected bool timer_Elapsed()
    {
        var recentPosts = GetRecentPosts();

        try
        {
            if (recentPosts.Count != 0)
            {
                bool alreadyPlayedSound = false;

                foreach (var post in recentPosts)
                {
                    //check if post hasn't already been  notified
                    if (!lastRecentPosts.Any(x => x.pid == post.pid) && IsCategoryEnabled(post.category.cid))
                    {
                        if (cbOnlyNewTopics.Active && !post.isMainPost) continue;

                        string decodedTitle = HttpUtility.HtmlDecode(post.topic.title),
                            decodedContent = HttpUtility.HtmlDecode(RemoveHTML(post.content));

                        if (cbTitleContains.Active || cbBodyContains.Active)
                        {
                            string strToSearch = "";

                            if (cbTitleContains.Active) strToSearch += decodedTitle;
                            if (cbBodyContains.Active) strToSearch += decodedContent;

                            if (!strToSearch.Contains(textviewContains.Buffer.Text)) continue;
                        }

                        if (cbIgnoreUsers.Active && ignoredUsers.Contains(post.user.username)) continue;

                        string linkToPost = "https://forums.gta5-mods.com/post/" + post.pid.ToString();

                        string decodedCategory = HttpUtility.HtmlDecode(post.category.name);

                        string body;
                        if (decodedContent.Length > 100) body = decodedContent.Substring(0, 97) + "...";
                        else body = decodedContent;

                        TreeIter iter;

                        if (treeStore.IterNChildren() == 50)
                        {
                            //remove oldest item
                            treeStore.IterNthChild(out iter, 49);

                            treeStore.Remove(ref iter);
                        }

                        iter = treeStore.InsertWithValues(0, decodedCategory, decodedTitle, body, linkToPost);

                        tvNotifications.Selection.SelectIter(iter);

                        tvNotifications.ScrollToCell(treeStore.GetPath(iter), columnCategory, true, 0f, 0f);

                        if (!alreadyPlayedSound)
                        {
                            alreadyPlayedSound = true;

                            if (cbPlayNotificationSound.Active)
                            {
                                SystemSounds.Beep.Play();
                                Thread.Sleep(150);
                                SystemSounds.Beep.Play();
                            }
                        }

                        int platform = (int)Environment.OSVersion.Platform;

                        if (platform == 4 || platform == 128) //Unix
                        {
							var notify = new Notifications.Notification(decodedTitle, body, Gdk.Pixbuf.LoadFromResource("GTA5MFNotifier.Resources.icon.png"));
							notify.Timeout = 5000;

							notify.AddAction("click", "View in browser", (object o, ActionArgs args) =>
							{
								Process.Start(linkToPost);
							});

							notify.Show();
                        }
                        else if (platform != 6) //Windows (6 == MacOS)
						{
                            var notification = new GTA5MFNotifier.Notification(linkToPost, decodedTitle, body, 10, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Left);
							notification.Show();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            lastRecentPosts = recentPosts;
        }

        return true;
    }

    protected void cbEnable_Toggled(object sender, EventArgs e)
    {
        if (cbEnable.Active)
        {
            if (timeoutTag != 0)
            {
                GLib.Source.Remove(timeoutTag);
            }

            uint interval = 60000;

            switch (comboboxInterval.Active)
            {
                case 1:
                    interval = 2 * 60000;
                    break;
                case 2:
                    interval = 5 * 60000;
                    break;
                case 3:
                    interval = 10 * 60000;
                    break;
            }

            timeoutTag = GLib.Timeout.Add(interval, timer_Elapsed);

            if (cbIgnoreUsers.Active) ignoredUsers = (tvIgnoreUsers.Buffer.Text.Contains(';') ? tvIgnoreUsers.Buffer.Text.Split(';') : new string[] { tvIgnoreUsers.Buffer.Text });
            lastRecentPosts = GetRecentPosts();
        }
        else
        {
            if (timeoutTag != 0)
            {
                GLib.Source.Remove(timeoutTag);
                timeoutTag = 0;
            }
        }

        categoriesFrame.Sensitive = !cbEnable.Active;
        containsFrame.Sensitive = categoriesFrame.Sensitive;
        cbOnlyNewTopics.Sensitive = categoriesFrame.Sensitive;
        cbIgnoreUsers.Sensitive = categoriesFrame.Sensitive;
        tvIgnoreUsers.Sensitive = categoriesFrame.Sensitive;
        comboboxInterval.Sensitive = categoriesFrame.Sensitive;
    }

    protected void cbRunOnStartup_Toggled(object sender, EventArgs e)
    {
        if (cbRunOnStartup.Active) runSubkey.SetValue(REGISTRY_KEY_NAME, Assembly.GetExecutingAssembly().Location + " -startup");
        else runSubkey.DeleteValue(REGISTRY_KEY_NAME, false);
    }

    protected void statusIcon_Activate(object sender, EventArgs e)
    {
        this.Deiconify();
        this.Visible = true;
        statusIcon.Visible = false;
    }

    private void openSelectedTreeViewItem()
    {
        if (tvNotifications.Selection.CountSelectedRows() > 0)
        {
            TreeIter iter;

            if (tvNotifications.Selection.GetSelected(out iter))
            {
                string link = (string)treeStore.GetValue(iter, 3);

                Process.Start(link);
            }
        }
    }

    [GLib.ConnectBefore]
    protected void tvNotifications_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
        if (args.Event.Type == Gdk.EventType.TwoButtonPress && args.Event.Button == 1) //double left-click
        {
            openSelectedTreeViewItem();
        }
    }

    protected void tvNotifications_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
        if (args.Event.Key == Gdk.Key.Return) openSelectedTreeViewItem();
    }

    private List<Post> GetRecentPosts()
    {
        string recentPostsJSON = string.Empty;

        try
        {
            var request = WebRequest.Create("https://forums.gta5-mods.com/api/recent/posts");

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        recentPostsJSON = reader.ReadToEnd();
                    }
                }
            }
        }
        catch (Exception)
        {
            return lastRecentPosts;
        }

        if (!string.IsNullOrWhiteSpace(recentPostsJSON))
        {
            List<Post> recentPosts;

            try
            {
                recentPosts = JsonConvert.DeserializeObject<List<Post>>(recentPostsJSON);
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Error deserializing json: " + ex.ToString());
                dialog.Run();
                dialog.Destroy();

                return lastRecentPosts;
            }

            return recentPosts;
        }

        return lastRecentPosts;
    }

    private string RemoveHTML(string htmlInfestedString)
    {
        return Regex.Replace(Regex.Replace(htmlInfestedString, @"<[^>]+>|&nbsp;", "").Trim(), @"\s{2,}", " ");
    }

    private bool IsCategoryEnabled(uint categoryId)
    {
        switch (categoryId)
        {
            case 1: return cbAnnouncements.Active; //announcements
            //case 2: return cbOffTopic.Active; //off-topic
            case 5: return cbGeneralModding.Active; //general modding
            case 6: return cbReleasesWIP.Active; //releases and wips
            case 7: return cbRequests.Active; //requests
            case 8: return cbTutorials.Active; //tutorials
            case 9: return cbSiteQuestions.Active; //site-related questions and feedback
            case 10: return cbInstallationHelp.Active; //installation help
            case 11: return cbDocumentation.Active; //documentation
        }

        return true;
    }

    private List<uint> GenerateListOfEnabledCategories()
    {
        List<uint> enabledCategories = new List<uint>();

        if (cbAnnouncements.Active) enabledCategories.Add(1); //announcements
        //if (cbOffTopic.Active) enabledCategories.Add(2); //off-topic
        if (cbGeneralModding.Active) enabledCategories.Add(5); //general modding
        if (cbReleasesWIP.Active) enabledCategories.Add(6); //releases and wips
        if (cbRequests.Active) enabledCategories.Add(7); //requests
        if (cbTutorials.Active) enabledCategories.Add(8); //tutorials
        if (cbSiteQuestions.Active) enabledCategories.Add(9); //site-related questions and feedback
        if (cbInstallationHelp.Active) enabledCategories.Add(10); //installation help
        if (cbDocumentation.Active) enabledCategories.Add(11); //documentation

        return enabledCategories;
    }

    private void SetCheckedCategoryCheckboxesFromList(List<uint> enabledCategories)
    {
        foreach (uint category in enabledCategories)
        {
            switch (category)
            {
                case 1: //announcements
                    cbAnnouncements.Active = true;
                    break;
                //case 2: //off-topic
                //cbOffTopic.Active = true;
                //break;
                case 5: //general modding
                    cbGeneralModding.Active = true;
                    break;
                case 6: //releases and wips
                    cbReleasesWIP.Active = true;
                    break;
                case 7: //requests
                    cbRequests.Active = true;
                    break;
                case 8: //tutorials
                    cbTutorials.Active = true;
                    break;
                case 9: //site-related questions and feedback
                    cbSiteQuestions.Active = true;
                    break;
                case 10: //installation help
                    cbInstallationHelp.Active = true;
                    break;
                case 11: //documentation
                    cbDocumentation.Active = true;
                    break;
            }
        }
    }
}
