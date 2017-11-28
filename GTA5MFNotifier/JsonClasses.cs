using Newtonsoft.Json;
using System;

class JsonClasses
{
    //json objects returned by forums.gta5-mods.com

    public class Category
    {
        [JsonProperty]
        public uint cid { get; set; }

        [JsonProperty]
        public string name { get; set; }

        [JsonProperty]
        public string icon { get; set; }

        [JsonProperty]
        public string slug { get; set; }

        [JsonProperty]
        public uint parentCid { get; set; }

        [JsonProperty]
        public string bgColor { get; set; } //hex color code

        [JsonProperty]
        public string color { get; set; } //hex color code
    }

    public class Topic
    {
        [JsonProperty]
        public uint uid { get; set; }

        [JsonProperty]
        public uint tid { get; set; }

        [JsonProperty]
        public string title { get; set; }

        [JsonProperty]
        public uint cid { get; set; }

        [JsonProperty]
        public string slug { get; set; }

        [JsonProperty]
        public bool deleted { get; set; }

        [JsonProperty]
        public uint postcount { get; set; }

        [JsonProperty]
        public uint mainPid { get; set; }
    }

    public class User
    {
        [JsonProperty]
        public uint uid { get; set; }

        [JsonProperty]
        public string username { get; set; }

        [JsonProperty]
        public string userslug { get; set; }

        [JsonProperty]
        public string picture { get; set; } //url

        [JsonProperty(PropertyName = "icon:text")]
        public char icontext { get; set; }

        [JsonProperty(PropertyName = "icon:bgColor")]
        public string iconbgColor { get; set; } //hex color code
    }

    public class Post
    {
        [JsonProperty]
        public uint pid { get; set; }

        [JsonProperty]
        public uint tid { get; set; }

        [JsonProperty]
        public string content { get; set; }

        [JsonProperty]
        public uint uid { get; set; }

        [JsonProperty]
        public UInt64 timestamp { get; set; }

        [JsonProperty]
        public bool deleted { get; set; }

        [JsonProperty]
        public uint upvotes { get; set; }

        [JsonProperty]
        public uint downvotes { get; set; }

        [JsonProperty]
        public User user { get; set; }

        [JsonProperty]
        public Topic topic { get; set; }

        [JsonProperty]
        public Category category { get; set; }

        [JsonProperty]
        public bool isMainPost { get; set; }

        [JsonProperty]
        public int votes { get; set; }

        [JsonProperty]
        public string timestampISO { get; set; }
    }
}
