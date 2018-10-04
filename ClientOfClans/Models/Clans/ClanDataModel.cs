using System;
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
        public MemberList[] MemberList { get; set; }
    }

    internal struct BadgeUrls
    {
        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }
    }

    internal struct MemberList
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("expLevel")]
        public int ExpLevel { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("trophies")]
        public int Trophies { get; set; }

        [JsonProperty("versusTrophies")]
        public int VersusTrophies { get; set; }

        [JsonProperty("clanRank")]
        public int ClanRank { get; set; }

        [JsonProperty("previousClanRank")]
        public int PreviousClanRank { get; set; }

        [JsonProperty("donations")]
        public int Donations { get; set; }

        [JsonProperty("donationsReceived")]
        public int DonationsReceived { get; set; }
    }

    internal struct League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iconUrls")]
        public IconUrls IconUrls { get; set; }
    }

    internal struct IconUrls
    {
        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("tiny")]
        public Uri Tiny { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }
    }
}
