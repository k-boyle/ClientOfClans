using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientOfClans.Models;
using ClientOfClans.Models.Clans;
using ClientOfClans.Objects;
using ClientOfClans.Objects.Clans;
using ClientOfClans.RequestParameters;
using Newtonsoft.Json;
using ClanDataModel = ClientOfClans.Models.Clans.ClanDataModel;

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
            var clans = await _requests.SendRequestAsync<ClansDataModel>("clans", parameters).ConfigureAwait(false);
            
            return new ClansSearchResult
            {
                After = clans.Paging.Cursors.After,
                Before = clans.Paging.Cursors.Before,
                Clans = ProcessClans(clans.Items).ToList()
            };
        }

        /// <summary>
        /// Gets the clan members of the default tag in config.
        /// </summary>
        /// <param name="parameters">The filtering parameters to use.</param>
        /// <returns>A ClanMembersResult that yields the results of the request.</returns>
        public Task<ClanMembersResult> GetClanMembersAsync(ClanMembersParameters parameters = null)
            => GetClanMembersAsync(string.Empty, parameters);

        /// <summary>
        /// Get the clan members of the specified tag.
        /// </summary>
        /// <param name="clanTag">The clan tag that you want the members for.</param>
        /// <param name="parameters">The filtering parameters to use.</param>
        /// <returns>A ClanMembersResult that yields the results of the request</returns>
        public async Task<ClanMembersResult> GetClanMembersAsync(string clanTag, ClanMembersParameters parameters = null)
        {
            var tag = GetClanTag(clanTag);

            var members = await _requests.SendRequestAsync<ClanMembersDataModel>($"clans/{tag}/members", parameters).ConfigureAwait(false);

            var memberList = members.Items.Select(x => new ClanMember(x)).ToList();

            return new ClanMembersResult
            {
                After = members.Paging.Cursors.After,
                Before = members.Paging.Cursors.Before,
                ClanMembers = memberList
            };
        }

        private static IEnumerable<ClanData> ProcessClans(IEnumerable<ClanDataModel> items)
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
