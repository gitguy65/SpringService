using SpringService.Models;
using System.Net.Http.Json;

namespace SpringService.Services
{
    public class ReviewServiceAsync
    {
        HttpClient httpClient;
        List<Review> reviews = new();

        public ReviewServiceAsync()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Review>> GetReviews()
        {
            if (reviews.Count > 0)
                return reviews;
#if DEBUG
            string url = "http://link-to-api/api/";
#else
            string url = "https://link-to-api/api/";
#endif
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                reviews = await response.Content.ReadFromJsonAsync<List<Review>>();
            }

            return reviews;
        }
    }
}
