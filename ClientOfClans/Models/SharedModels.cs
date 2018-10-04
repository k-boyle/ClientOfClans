using System;
using Newtonsoft.Json;

namespace ClientOfClans.Models
{
    internal struct BadgeUrls
    {
        [JsonProperty("tiny")]
        public Uri Tiny { get; set; }

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

    internal struct League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iconUrls")]
        public BadgeUrls IconUrls { get; set; }
    }

    internal struct ClanDataModel
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

    internal struct ClanMemberModel
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
}
