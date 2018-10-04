using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ClientOfClans.RequestParameters;

namespace ClientOfClans
{
    internal class Requests
    {
        private readonly HttpClient _client;
        private readonly SemaphoreSlim _semaphore;

        public Requests(string token)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.clashofclans.com/v1/")
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            
            _semaphore = new SemaphoreSlim(0, 5);

            var timer = new Timer(_ => { _semaphore.Release(5); }, 
                null, 
                TimeSpan.Zero, 
                TimeSpan.FromSeconds(5));
        }

        public async Task<T> SendRequestAsync<T>(string endpoint, IRequestParameters parameters = null)
        {
            var parameterResult = parameters?.VerifyParameters();

            if(parameterResult?.Failed == true)
                throw new Exception(parameterResult.Reason);

            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                using (var response = await _client.GetAsync($"{endpoint}{parameters?.GenerateQuery()}").ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new Exception(response.ReasonPhrase);
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }
    }
}
