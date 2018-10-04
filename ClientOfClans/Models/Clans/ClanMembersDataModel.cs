using Newtonsoft.Json;

namespace ClientOfClans.Models.Clans
{
    internal struct ClanMembersDataModel
    {
        [JsonProperty("items")]
        public ClanMemberModel[] Items { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}
