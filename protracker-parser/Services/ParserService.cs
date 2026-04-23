using System.Net.Http;

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

            string url = $"https://api.opendota.com/api/heroes/{heroId}";           
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
