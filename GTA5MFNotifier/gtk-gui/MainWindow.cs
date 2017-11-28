
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;

	private global::Gtk.HBox hbox1;

	private global::Gtk.Frame categoriesFrame;

	private global::Gtk.Alignment GtkAlignment;

	private global::Gtk.HBox hbox2;

	private global::Gtk.VBox vbox5;

	private global::Gtk.CheckButton cbAnnouncements;

	private global::Gtk.CheckButton cbGeneralModding;

	private global::Gtk.CheckButton cbReleasesWIP;

	private global::Gtk.CheckButton cbRequests;

	private global::Gtk.VBox vbox6;

	private global::Gtk.CheckButton cbTutorials;

	private global::Gtk.CheckButton cbSiteQuestions;

	private global::Gtk.CheckButton cbInstallationHelp;

	private global::Gtk.CheckButton cbDocumentation;

	private global::Gtk.Label GtkLabel8;

	private global::Gtk.VBox vbox7;

	private global::Gtk.CheckButton cbOnlyNewTopics;

	private global::Gtk.VBox vbox8;

	private global::Gtk.HBox hbox3;

	private global::Gtk.CheckButton cbIgnoreUsers;

	private global::Gtk.TextView tvIgnoreUsers;

	private global::Gtk.Frame containsFrame;

	private global::Gtk.Alignment GtkAlignment1;

	private global::Gtk.VBox vbox2;

	private global::Gtk.HBox hbox4;

	private global::Gtk.CheckButton cbTitleContains;

	private global::Gtk.Label label3;

	private global::Gtk.CheckButton cbBodyContains;

	private global::Gtk.TextView textviewContains;

	private global::Gtk.Label GtkLabel14;

	private global::Gtk.HBox hbox7;

	private global::Gtk.CheckButton cbEnable;

	private global::Gtk.CheckButton cbPlayNotificationSound;

	private global::Gtk.CheckButton cbRunOnStartup;

	private global::Gtk.ComboBox comboboxInterval;

	private global::Gtk.ScrolledWindow GtkScrolledWindow2;

	private global::Gtk.TreeView tvNotifications;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = "GTA5MF Notifier";
		this.Icon = global::Gdk.Pixbuf.LoadFromResource("GTA5MFNotifier.Resources.icon.png");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.categoriesFrame = new global::Gtk.Frame();
		this.categoriesFrame.Name = "categoriesFrame";
		this.categoriesFrame.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child categoriesFrame.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox5 = new global::Gtk.VBox();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		// Container child vbox5.Gtk.Box+BoxChild
		this.cbAnnouncements = new global::Gtk.CheckButton();
		this.cbAnnouncements.CanFocus = true;
		this.cbAnnouncements.Name = "cbAnnouncements";
		this.cbAnnouncements.Label = "Announcements";
		this.cbAnnouncements.Active = true;
		this.cbAnnouncements.DrawIndicator = true;
		this.cbAnnouncements.UseUnderline = true;
		this.vbox5.Add(this.cbAnnouncements);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.cbAnnouncements]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.cbGeneralModding = new global::Gtk.CheckButton();
		this.cbGeneralModding.CanFocus = true;
		this.cbGeneralModding.Name = "cbGeneralModding";
		this.cbGeneralModding.Label = "General Modding";
		this.cbGeneralModding.Active = true;
		this.cbGeneralModding.DrawIndicator = true;
		this.cbGeneralModding.UseUnderline = true;
		this.vbox5.Add(this.cbGeneralModding);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.cbGeneralModding]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.cbReleasesWIP = new global::Gtk.CheckButton();
		this.cbReleasesWIP.CanFocus = true;
		this.cbReleasesWIP.Name = "cbReleasesWIP";
		this.cbReleasesWIP.Label = "Releases & WIPs";
		this.cbReleasesWIP.Active = true;
		this.cbReleasesWIP.DrawIndicator = true;
		this.cbReleasesWIP.UseUnderline = true;
		this.vbox5.Add(this.cbReleasesWIP);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.cbReleasesWIP]));
		w3.Position = 2;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.cbRequests = new global::Gtk.CheckButton();
		this.cbRequests.CanFocus = true;
		this.cbRequests.Name = "cbRequests";
		this.cbRequests.Label = "Requests";
		this.cbRequests.Active = true;
		this.cbRequests.DrawIndicator = true;
		this.cbRequests.UseUnderline = true;
		this.vbox5.Add(this.cbRequests);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.cbRequests]));
		w4.Position = 3;
		w4.Expand = false;
		w4.Fill = false;
		this.hbox2.Add(this.vbox5);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox5]));
		w5.Position = 0;
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox6 = new global::Gtk.VBox();
		this.vbox6.Name = "vbox6";
		this.vbox6.Spacing = 6;
		// Container child vbox6.Gtk.Box+BoxChild
		this.cbTutorials = new global::Gtk.CheckButton();
		this.cbTutorials.CanFocus = true;
		this.cbTutorials.Name = "cbTutorials";
		this.cbTutorials.Label = "Tutorials";
		this.cbTutorials.Active = true;
		this.cbTutorials.DrawIndicator = true;
		this.cbTutorials.UseUnderline = true;
		this.vbox6.Add(this.cbTutorials);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.cbTutorials]));
		w6.Position = 0;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox6.Gtk.Box+BoxChild
		this.cbSiteQuestions = new global::Gtk.CheckButton();
		this.cbSiteQuestions.CanFocus = true;
		this.cbSiteQuestions.Name = "cbSiteQuestions";
		this.cbSiteQuestions.Label = "Site Questions & Feedback";
		this.cbSiteQuestions.Active = true;
		this.cbSiteQuestions.DrawIndicator = true;
		this.cbSiteQuestions.UseUnderline = true;
		this.vbox6.Add(this.cbSiteQuestions);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.cbSiteQuestions]));
		w7.Position = 1;
		w7.Expand = false;
		w7.Fill = false;
		// Container child vbox6.Gtk.Box+BoxChild
		this.cbInstallationHelp = new global::Gtk.CheckButton();
		this.cbInstallationHelp.CanFocus = true;
		this.cbInstallationHelp.Name = "cbInstallationHelp";
		this.cbInstallationHelp.Label = "Installation Help";
		this.cbInstallationHelp.Active = true;
		this.cbInstallationHelp.DrawIndicator = true;
		this.cbInstallationHelp.UseUnderline = true;
		this.vbox6.Add(this.cbInstallationHelp);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.cbInstallationHelp]));
		w8.Position = 2;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox6.Gtk.Box+BoxChild
		this.cbDocumentation = new global::Gtk.CheckButton();
		this.cbDocumentation.CanFocus = true;
		this.cbDocumentation.Name = "cbDocumentation";
		this.cbDocumentation.Label = "Documentation";
		this.cbDocumentation.Active = true;
		this.cbDocumentation.DrawIndicator = true;
		this.cbDocumentation.UseUnderline = true;
		this.vbox6.Add(this.cbDocumentation);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.cbDocumentation]));
		w9.Position = 3;
		w9.Expand = false;
		w9.Fill = false;
		this.hbox2.Add(this.vbox6);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox6]));
		w10.Position = 1;
		this.GtkAlignment.Add(this.hbox2);
		this.categoriesFrame.Add(this.GtkAlignment);
		this.GtkLabel8 = new global::Gtk.Label();
		this.GtkLabel8.Name = "GtkLabel8";
		this.GtkLabel8.LabelProp = "<b>Categories to check</b>";
		this.GtkLabel8.UseMarkup = true;
		this.categoriesFrame.LabelWidget = this.GtkLabel8;
		this.hbox1.Add(this.categoriesFrame);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.categoriesFrame]));
		w13.Position = 0;
		w13.Expand = false;
		w13.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.vbox7 = new global::Gtk.VBox();
		this.vbox7.Name = "vbox7";
		this.vbox7.Spacing = -3;
		// Container child vbox7.Gtk.Box+BoxChild
		this.cbOnlyNewTopics = new global::Gtk.CheckButton();
		this.cbOnlyNewTopics.CanFocus = true;
		this.cbOnlyNewTopics.Name = "cbOnlyNewTopics";
		this.cbOnlyNewTopics.Label = "Only new topics";
		this.cbOnlyNewTopics.DrawIndicator = true;
		this.cbOnlyNewTopics.UseUnderline = true;
		this.vbox7.Add(this.cbOnlyNewTopics);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.cbOnlyNewTopics]));
		w14.Position = 0;
		// Container child vbox7.Gtk.Box+BoxChild
		this.vbox8 = new global::Gtk.VBox();
		this.vbox8.Name = "vbox8";
		this.vbox8.Spacing = 6;
		// Container child vbox8.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.cbIgnoreUsers = new global::Gtk.CheckButton();
		this.cbIgnoreUsers.CanFocus = true;
		this.cbIgnoreUsers.Name = "cbIgnoreUsers";
		this.cbIgnoreUsers.Label = "Ignore users:";
		this.cbIgnoreUsers.DrawIndicator = true;
		this.cbIgnoreUsers.UseUnderline = true;
		this.hbox3.Add(this.cbIgnoreUsers);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.cbIgnoreUsers]));
		w15.Position = 0;
		w15.Expand = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.tvIgnoreUsers = new global::Gtk.TextView();
		this.tvIgnoreUsers.TooltipMarkup = "Seperate multiple users with semicolons";
		this.tvIgnoreUsers.CanFocus = true;
		this.tvIgnoreUsers.Name = "tvIgnoreUsers";
		this.hbox3.Add(this.tvIgnoreUsers);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.tvIgnoreUsers]));
		w16.Position = 1;
		this.vbox8.Add(this.hbox3);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.hbox3]));
		w17.Position = 0;
		w17.Expand = false;
		w17.Fill = false;
		this.vbox7.Add(this.vbox8);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.vbox8]));
		w18.Position = 1;
		// Container child vbox7.Gtk.Box+BoxChild
		this.containsFrame = new global::Gtk.Frame();
		this.containsFrame.Name = "containsFrame";
		this.containsFrame.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child containsFrame.Gtk.Container+ContainerChild
		this.GtkAlignment1 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment1.Name = "GtkAlignment1";
		this.GtkAlignment1.LeftPadding = ((uint)(12));
		// Container child GtkAlignment1.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.cbTitleContains = new global::Gtk.CheckButton();
		this.cbTitleContains.CanFocus = true;
		this.cbTitleContains.Name = "cbTitleContains";
		this.cbTitleContains.Label = "In title";
		this.cbTitleContains.DrawIndicator = true;
		this.cbTitleContains.UseUnderline = true;
		this.hbox4.Add(this.cbTitleContains);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.cbTitleContains]));
		w19.Position = 0;
		w19.Expand = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.label3 = new global::Gtk.Label();
		this.label3.Name = "label3";
		this.label3.Xpad = 15;
		this.label3.LabelProp = "or";
		this.hbox4.Add(this.label3);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label3]));
		w20.Position = 1;
		w20.Expand = false;
		w20.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.cbBodyContains = new global::Gtk.CheckButton();
		this.cbBodyContains.CanFocus = true;
		this.cbBodyContains.Name = "cbBodyContains";
		this.cbBodyContains.Label = "In body";
		this.cbBodyContains.DrawIndicator = true;
		this.cbBodyContains.UseUnderline = true;
		this.hbox4.Add(this.cbBodyContains);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.cbBodyContains]));
		w21.Position = 2;
		w21.Expand = false;
		this.vbox2.Add(this.hbox4);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
		w22.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.textviewContains = new global::Gtk.TextView();
		this.textviewContains.CanFocus = true;
		this.textviewContains.Name = "textviewContains";
		this.vbox2.Add(this.textviewContains);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.textviewContains]));
		w23.Position = 1;
		this.GtkAlignment1.Add(this.vbox2);
		this.containsFrame.Add(this.GtkAlignment1);
		this.GtkLabel14 = new global::Gtk.Label();
		this.GtkLabel14.Name = "GtkLabel14";
		this.GtkLabel14.LabelProp = "<b>Contains</b>";
		this.GtkLabel14.UseMarkup = true;
		this.containsFrame.LabelWidget = this.GtkLabel14;
		this.vbox7.Add(this.containsFrame);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.containsFrame]));
		w26.PackType = ((global::Gtk.PackType)(1));
		w26.Position = 2;
		this.hbox1.Add(this.vbox7);
		global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox7]));
		w27.Position = 1;
		this.vbox1.Add(this.hbox1);
		global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
		w28.Position = 0;
		w28.Expand = false;
		w28.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox7 = new global::Gtk.HBox();
		this.hbox7.Name = "hbox7";
		this.hbox7.Spacing = 6;
		// Container child hbox7.Gtk.Box+BoxChild
		this.cbEnable = new global::Gtk.CheckButton();
		this.cbEnable.CanFocus = true;
		this.cbEnable.Name = "cbEnable";
		this.cbEnable.Label = "Enable";
		this.cbEnable.DrawIndicator = true;
		this.cbEnable.UseUnderline = true;
		this.hbox7.Add(this.cbEnable);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.cbEnable]));
		w29.Position = 0;
		// Container child hbox7.Gtk.Box+BoxChild
		this.cbPlayNotificationSound = new global::Gtk.CheckButton();
		this.cbPlayNotificationSound.CanFocus = true;
		this.cbPlayNotificationSound.Name = "cbPlayNotificationSound";
		this.cbPlayNotificationSound.Label = "Play notification sound";
		this.cbPlayNotificationSound.Active = true;
		this.cbPlayNotificationSound.DrawIndicator = true;
		this.cbPlayNotificationSound.UseUnderline = true;
		this.hbox7.Add(this.cbPlayNotificationSound);
		global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.cbPlayNotificationSound]));
		w30.Position = 1;
		// Container child hbox7.Gtk.Box+BoxChild
		this.cbRunOnStartup = new global::Gtk.CheckButton();
		this.cbRunOnStartup.CanFocus = true;
		this.cbRunOnStartup.Name = "cbRunOnStartup";
		this.cbRunOnStartup.Label = "Run on startup";
		this.cbRunOnStartup.DrawIndicator = true;
		this.cbRunOnStartup.UseUnderline = true;
		this.hbox7.Add(this.cbRunOnStartup);
		global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.cbRunOnStartup]));
		w31.Position = 2;
		// Container child hbox7.Gtk.Box+BoxChild
		this.comboboxInterval = global::Gtk.ComboBox.NewText();
		this.comboboxInterval.AppendText("Check every 1 min");
		this.comboboxInterval.AppendText("Check every 2 min");
		this.comboboxInterval.AppendText("Check every 5 min");
		this.comboboxInterval.AppendText("Check every 10 min");
		this.comboboxInterval.Name = "comboboxInterval";
		this.comboboxInterval.Active = 0;
		this.hbox7.Add(this.comboboxInterval);
		global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.comboboxInterval]));
		w32.Position = 3;
		w32.Expand = false;
		w32.Fill = false;
		this.vbox1.Add(this.hbox7);
		global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox7]));
		w33.Position = 1;
		w33.Expand = false;
		w33.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
		this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
		this.tvNotifications = new global::Gtk.TreeView();
		this.tvNotifications.CanFocus = true;
		this.tvNotifications.Name = "tvNotifications";
		this.GtkScrolledWindow2.Add(this.tvNotifications);
		this.vbox1.Add(this.GtkScrolledWindow2);
		global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow2]));
		w35.Position = 2;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 638;
		this.DefaultHeight = 436;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.cbEnable.Toggled += new global::System.EventHandler(this.cbEnable_Toggled);
		this.tvNotifications.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler(this.tvNotifications_ButtonPressEvent);
		this.tvNotifications.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler(this.tvNotifications_KeyReleaseEvent);
	}
}
