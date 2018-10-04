using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientOfClans.Models.Clans;
using ClientOfClans.Objects.Clans;
using ClientOfClans.RequestParameters;
using Newtonsoft.Json;

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

        /// <summary>
        /// Gets clan data of the clan whose tag is the default tag in config.
        /// </summary>
        /// <returns>A ClanData object that holds all the information of a clan.</returns>
        public Task<ClanData> GetClanDataAsync()
            => GetClanDataAsync(GetClanTag(string.Empty));

        /// <summary>
        /// Gets clan data of the specific clan tag.
        /// </summary>
        /// <param name="clanTag">The clan tag of the clan you want data on.</param>
        /// <returns>A ClanData object that holds all the information of clan.</returns>
        public async Task<ClanData> GetClanDataAsync(string clanTag)
        {
            var tag = GetClanTag(clanTag);

            return await ClanData.CreateClanDataAsync(_requests, tag).ConfigureAwait(false);
        }

        /// <summary>
        /// Searchs for clans based on the search parameters.
        /// </summary>
        /// <param name="parameters">The search parameters to use.</param>
        /// <returns>A ClansSearchResult object that yields the results of the search.</returns>
        public async Task<ClansSearchResult> SearchClansAsync(ClanParameters parameters)
        {
            var clanList = new List<ClanData>();

            var clans = await _requests.SendRequestAsync<ClansDataModel>("clans", parameters);
            
            clanList.AddRange(ProcessClans(clans.Items));

            return new ClansSearchResult
            {
                After = clans.Paging.Cursors.After,
                Before = clans.Paging.Cursors.Before,
                Clans = clanList
            };
        }

        private static IEnumerable<ClanData> ProcessClans(IEnumerable<Item> items)
            => items.Select(item => ClanData.CreateClanData(JsonConvert.DeserializeObject<ClanDataModel>(JsonConvert.SerializeObject(item))));

        private string GetClanTag(string clanTag)
        {
            if (string.IsNullOrWhiteSpace(clanTag) &&
                (_config is null || string.IsNullOrWhiteSpace(_config?.DefaultClanTag)))
                throw new ArgumentNullException(nameof(clanTag));

            return (string.IsNullOrWhiteSpace(clanTag) ? _config.DefaultClanTag : clanTag).Replace("#", "%23");
        }
    }
}
