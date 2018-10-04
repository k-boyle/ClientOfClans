using Newtonsoft.Json;

namespace ClientOfClans.Models.Clans
{
    internal struct ClansDataModel
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    internal struct Item
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("badgeUrls")]
        public BadgeUrls BadgeUrls { get; set; }

        [JsonProperty("clanLevel")]
        public int ClanLevel { get; set; }

        [JsonProperty("clanPoints")]
        public int ClanPoints { get; set; }

        [JsonProperty("clanVersusPoints")]
        public int ClanVersusPoints { get; set; }

        [JsonProperty("requiredTrophies")]
        public int RequiredTrophies { get; set; }

        [JsonProperty("warFrequency")]
        public string WarFrequency { get; set; }

        [JsonProperty("warWinStreak")]
        public int WarWinStreak { get; set; }

        [JsonProperty("warWins")]
        public int WarWins { get; set; }

        [JsonProperty("warTies", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarTies { get; set; }

        [JsonProperty("warLosses", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarLosses { get; set; }

        [JsonProperty("isWarLogPublic")]
        public bool IsWarLogPublic { get; set; }

        [JsonProperty("members")]
        public int Members { get; set; }
    }
}
