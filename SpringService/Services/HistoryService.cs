using SpringService.Models;
using System.Net.Http.Json;

namespace SpringService.Services
{
    public class HistoryService
    {
        HttpClient httpClient;
        List<History> history = new();

        public HistoryService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<History>> GetHistory()
        {
            if (history.Count > 0)
                return history;

#if DEBUG
            string url = "http://link-to-api/api/";
#else
            string url = "https://link-to-api/api/";
#endif

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                history = await response.Content.ReadFromJsonAsync<List<History>>();
            }
            return history;
        }
    }
}
