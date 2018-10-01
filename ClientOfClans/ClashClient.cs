using System;
using System.Threading.Tasks;
using ClientOfClans.Objects.Clans;

namespace ClientOfClans
{
    public class ClashClient
    {
        private readonly Config _config;
        private readonly Requests _requests;

        public ClashClient(string token)
        {
            _requests = new Requests(token);
        }

        public ClashClient(Config config)
        {
            _config = config;

            _requests = new Requests(_config.Token);
        }

        public async Task<ClanData> GetClanDataAsync(string clanTag = "")
        {
            if (string.IsNullOrWhiteSpace(clanTag) &&
                    (_config is null || string.IsNullOrWhiteSpace(_config?.DefaultClanTag)))
                throw new ArgumentNullException(nameof(clanTag));

            var tag = string.IsNullOrWhiteSpace(clanTag) ? _config.DefaultClanTag : clanTag;

            return await ClanData.CreateClanDataAsync(_requests, tag.Replace("#", "%23")).ConfigureAwait(false);
        }
    }
}
