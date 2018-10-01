using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = ClientOfClans.Models.Clans.ClanDataModel;

namespace ClientOfClans.Objects.Clans
{
    public class ClanData
    {
        private readonly Model _model;

        public string Tag => _model.Tag;
        public string Name => _model.Name;
        public string Description => _model.Description;

        public int Level => _model.ClanLevel;
        public int Points => _model.ClanPoints;
        public int VersusPoints => _model.ClanVersusPoints;
        public int RequiredTrophies => _model.RequiredTrophies;
        public int MemberCount => _model.Members;

        public bool PublicWarLog => _model.IsWarLogPublic;

        public JoinType JoinType
        {
            get
            {
                switch (_model.Type)
                {
                    case "inviteOnly":
                        return JoinType.InviteOnly;

                    case "open":
                        return JoinType.Open;

                    case "closed":
                        return JoinType.Closed;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(_model.Type));
                }
            }
        }

        public WarFrequency WarFrequency
        {
            get
            {
                switch (_model.WarFrequency)
                {
                    case "always":
                        return WarFrequency.Always;

                    case "moreThanOncePerWeek":
                        return WarFrequency.MoreThanOncePerWeek;

                    case "oncePerWeek":
                        return WarFrequency.OncePerWeek;

                    case "lessThanOncePerWeek":
                        return WarFrequency.LessThanOncePerWeek;

                    case "never":
                        return WarFrequency.Never;

                    case "unknown":
                        return WarFrequency.Unknown;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(_model.WarFrequency));
                }
            }
        }

        public Location Location => new Location
        {
            Id = _model.Location.Id,
            CountryCode = _model.Location.CountryCode,
            IsCountry = _model.Location.IsCountry,
            Name = _model.Location.Name
        };

        public ImageUris BadgeUrls => new ImageUris
        {
            Large = _model.BadgeUrls.Large,
            Medium = _model.BadgeUrls.Medium,
            Small = _model.BadgeUrls.Small
        };

        public ClanWarStats WarStats => new ClanWarStats
        {
            Losses = _model.WarLosses,
            Ties = _model.WarTies,
            Wins = _model.WarWins,
            WinStreak = _model.WarWinStreak
        };

        public IEnumerable<ClanMember> GetClanMembers()
        {
            foreach (var member in _model.MemberList)
            {
                var newMember = new ClanMember
                {
                    ClanRank = member.ClanRank,
                    Donations = member.Donations,
                    League = new League
                    {
                        IconUrls = new ImageUris
                        {
                            Tiny = member.League.IconUrls.Tiny,
                            Medium = member.League.IconUrls.Medium,
                            Small = member.League.IconUrls.Small
                        },
                        Id = member.League.Id,
                        Name = member.League.Name
                    },
                    Level = member.ExpLevel,
                    Name = member.Name,
                    PreviousClanRank = member.PreviousClanRank,
                    Received = member.DonationsReceived,
                    Tag = member.Tag,
                    Trophies = member.Trophies,
                    VersusTrophies = member.VersusTrophies
                };

                switch (member.Role)
                {
                    case "admin":
                        newMember.Role = ClanRole.Elder;
                        break;

                    case "coLeader":
                        newMember.Role = ClanRole.CoLeader;
                        break;

                    case "member":
                        newMember.Role = ClanRole.Member;
                        break;

                    case "leader":
                        newMember.Role = ClanRole.Leader;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(member));
                }

                yield return newMember;
            }
        }

        private ClanData(Model model)
            => _model = model;

        internal static async Task<ClanData> CreateClanDataAsync(Requests requests, string clanTag)
            => new ClanData(await requests.SendRequestAsync<Model>($"/clans/{clanTag}").ConfigureAwait(false));
    }
}
