using System;
using Newtonsoft.Json;

namespace ClientOfClans.Models
{
    internal struct BadgeUrls
    {
        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }
    }

    internal struct Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }
    }

    internal struct Cursors
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }

    internal struct Location
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isCountry")]
        public bool IsCountry { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}
