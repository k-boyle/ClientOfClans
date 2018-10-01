using System;

namespace ClientOfClans.Objects
{
    public class Location
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool IsCountry { get; internal set; }
        public string CountryCode { get; internal set; }
    }

    public class ImageUris
    {
        public Uri Tiny { get; internal set; }
        public Uri Small { get; internal set; }
        public Uri Medium { get; internal set; }
        public Uri Large { get; internal set; }
    }

    public class ClanWarStats
    {
        public int WinStreak { get; internal set; }
        public int Wins { get; internal set; }
        public int Ties { get; internal set; }
        public int Losses { get; internal set; }
    }

    public class ClanMember
    {
        public string Tag { get; internal set; }
        public string Name { get; internal set; }

        public int Level { get; internal set; }
        public int Trophies { get; internal set; }
        public int VersusTrophies { get; internal set; }
        public int ClanRank { get; internal set; }
        public int PreviousClanRank { get; internal set; }
        public int Donations { get; internal set; }
        public int Received { get; internal set; }

        public League League { get; internal set; }

        public ClanRole Role { get; internal set; }
    }

    public class League
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public ImageUris IconUrls { get; internal set; }
    }

    public enum ClanRole
    {
        Unknown,
        Member,
        CoLeader,
        Leader,
        Elder
    }

    public enum JoinType
    {
        Unknown,
        Closed,
        InviteOnly,
        Open
    }

    public enum WarFrequency
    {
        Unknown,
        Always,
        MoreThanOncePerWeek,
        OncePerWeek,
        LessThanOncePerWeek,
        Never
    }
}
