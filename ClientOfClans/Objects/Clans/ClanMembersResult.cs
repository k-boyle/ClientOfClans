using System.Collections.Generic;

namespace ClientOfClans.Objects.Clans
{
    public class ClanMembersResult
    {
        public IReadOnlyCollection<ClanMember> ClanMembers { get; internal set; }
        public string Before { get; internal set; }
        public string After { get; internal set; }
    }
}
