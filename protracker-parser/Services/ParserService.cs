using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace protracker_parser.Services
{

    public class ParserService
    {
        private readonly HttpClient _httpClient;

        public ParserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async public Task<string> Process(int heroId)
        {


            //string url = $"https://api.opendota.com/api/heroes/{heroId}";           
            string url = "https://api.opendota.com/api/heroStats";
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}