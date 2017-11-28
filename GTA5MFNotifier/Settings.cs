using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class ProgramSettings
{
    //settings of the program

    public class JSONSettings
    {
        [JsonProperty]
        public bool Enabled { get; set; }

        [JsonProperty]
        public bool PlaySound { get; set; }

        [JsonProperty]
        public List<uint> EnabledCategories { get; set; }

        [JsonProperty]
        public bool OnlyNewTopics { get; set; }

        [JsonProperty]
        public bool OnlyTitleContains { get; set; }

        [JsonProperty]
        public bool OnlyBodyContains { get; set; }

        [JsonProperty]
        public string Contains { get; set; }

        [JsonProperty]
        public bool IgnoreUsers { get; set; }

        [JsonProperty]
        public string Users { get; set; }

        [JsonProperty]
        public int IntervalIndex { get; set; }

        public JSONSettings(bool enabled, bool playSound, List<uint> enabledCategories, bool onlyNewTopics,
            bool onlyTitleContains, bool onlyBodyContains, string contains, bool ignoreUsers, string users, int intervalIndex)
        {
            Enabled = enabled;
            PlaySound = playSound;
            EnabledCategories = enabledCategories;
            OnlyNewTopics = onlyNewTopics;
            OnlyTitleContains = onlyTitleContains;
            OnlyBodyContains = onlyBodyContains;
            Contains = contains;
            IgnoreUsers = ignoreUsers;
            Users = users;
            IntervalIndex = intervalIndex;
        }
    }

    internal static void Save(JSONSettings settings, string fileName)
    {
        File.WriteAllText(fileName, JsonConvert.SerializeObject(settings));
    }

    internal static bool Load(string fileName, out JSONSettings settings)
    {
        string text = File.ReadAllText(fileName);

        if (string.IsNullOrWhiteSpace(text))
        {
            settings = null;
            return false;
        }

        JSONSettings js = JsonConvert.DeserializeObject<JSONSettings>(text);

        settings = js;
        return js != null;
    }
}