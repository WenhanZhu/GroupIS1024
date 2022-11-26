namespace GroupIS1024
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ChefAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("favoriteRecipe")]
        public string FavoriteRecipe { get; set; }
    }

    public partial class ChefAuthor
    {
        public static List<ChefAuthor> FromJson(string json) => JsonConvert.DeserializeObject<List<ChefAuthor>>(json, GroupIS1024.Converter2.Settings);
    }

    public static class Serialize2
    {
        public static string ToJson(this List<ChefAuthor> self) => JsonConvert.SerializeObject(self, GroupIS1024.Converter2.Settings);
    }

    internal static class Converter2
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
