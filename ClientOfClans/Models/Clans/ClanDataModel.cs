using Newtonsoft.Json;

namespace ClientOfClans.Models.Clans
{
    internal struct ClanDataModel
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

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

        [JsonProperty("warTies")]
        public int WarTies { get; set; }

        [JsonProperty("warLosses")]
        public int WarLosses { get; set; }

        [JsonProperty("isWarLogPublic")]
        public bool IsWarLogPublic { get; set; }

        [JsonProperty("members")]
        public int Members { get; set; }

        [JsonProperty("memberList")]
        public ClanMemberModel[] MemberList { get; set; }
    }
}
