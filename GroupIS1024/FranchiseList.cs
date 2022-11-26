﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GroupIS1024;
//
//    var franchiseList = FranchiseList.FromJson(jsonString);

namespace GroupIS1024
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FranchiseList
    {
        [JsonProperty("data")]
        public Franchise Franchise { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Franchise
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("conference")]
        public Conference Conference { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("next_page")]
        public object NextPage { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
    }

    public enum Conference { East, West };

    public partial class Franchise
    {
        public static List<Franchise> FromJson(string json) => JsonConvert.DeserializeObject<List<Franchise>>(json, GroupIS1024.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Franchise self) => JsonConvert.SerializeObject(self, GroupIS1024.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ConferenceConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ConferenceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Conference) || t == typeof(Conference?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "East":
                    return Conference.East;
                case "West":
                    return Conference.West;
            }
            throw new Exception("Cannot unmarshal type Conference");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Conference)untypedValue;
            switch (value)
            {
                case Conference.East:
                    serializer.Serialize(writer, "East");
                    return;
                case Conference.West:
                    serializer.Serialize(writer, "West");
                    return;
            }
            throw new Exception("Cannot marshal type Conference");
        }

        public static readonly ConferenceConverter Singleton = new ConferenceConverter();
    }
}
