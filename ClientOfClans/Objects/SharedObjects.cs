using ClientOfClans.Attributes;
using System;
using ClientOfClans.Models;

namespace ClientOfClans.Objects
{
    public struct Location
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool IsCountry { get; internal set; }
        public string CountryCode { get; internal set; }
    }

    public struct ImageUris
    {
        public Uri Tiny { get; internal set; }
        public Uri Small { get; internal set; }
        public Uri Medium { get; internal set; }
        public Uri Large { get; internal set; }
    }

    public struct ClanWarStats
    {
        public int WinStreak { get; internal set; }
        public int Wins { get; internal set; }
        public int Ties { get; internal set; }
        public int Losses { get; internal set; }
    }

    public struct ClanMember
    {
        internal ClanMember(ClanMemberModel model)
        {
            Tag = model.Tag;
            Name = model.Name;

            Level = model.ExpLevel;
            Trophies = model.Trophies;
            VersusTrophies = model.VersusTrophies;
            ClanRank = model.ClanRank;
            PreviousClanRank = model.PreviousClanRank;
            Donations = model.Donations;
            Received = model.DonationsReceived;

            League = new League
            {
                IconUrls = new ImageUris
                {
                    Large = model.League.IconUrls.Large,
                    Medium = model.League.IconUrls.Medium,
                    Small = model.League.IconUrls.Small,
                    Tiny = model.League.IconUrls.Tiny
                },

                Id = model.League.Id,

                Name = model.League.Name
            };

            switch (model.Role)
            {
                case "member":
                    Role = ClanRole.Member;
                    break;

                case "leader":
                    Role = ClanRole.Leader;
                    break;

                case "coLeader":
                    Role = ClanRole.CoLeader;
                    break;

                case "admin":
                    Role = ClanRole.Elder;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(model.Role));
            }
        }

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

    public struct League
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
        [StringValue("unkown")]
        Unknown,

        [StringValue("always")]
        Always,

        [StringValue("moreThanOncePerWeek")]
        MoreThanOncePerWeek,

        [StringValue("oncePerWeek")]
        OncePerWeek,

        [StringValue("lessThanOncePerWeek")]
        LessThanOncePerWeek,

        [StringValue("never")]
        Never
    }
}
