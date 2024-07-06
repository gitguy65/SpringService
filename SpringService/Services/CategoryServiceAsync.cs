using SpringService.Models;
using SpringService.Services.IService; 
using System.Net.Http.Json; 

namespace SpringService.Services
{
    public class CategoryServiceAsync : ICategoryService
    {
        private readonly HttpClient httpClient;
        public List<Category> Categories = [];

        public CategoryServiceAsync()
        {
            httpClient = new HttpClient();
        }
        public async Task<List<Category>> GetPopularServices()
        {
            if (Categories.Count > 0)
                return Categories;

            string url;

#if DEBUG
            url = "http://link-to-api/api/";
#else
            url = "https://link-to-api/api/";
#endif

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Categories = await response.Content.ReadFromJsonAsync<List<Category>>();
            }

            return Categories;
        }


    }
}
