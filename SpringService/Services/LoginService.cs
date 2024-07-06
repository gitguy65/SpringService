using SpringService.Models;
using System.Net.Http.Json;

namespace SpringService.Services
{
    public class LoginService
    {
        HttpClient httpClient;

        public LoginService()
        {
            httpClient = new HttpClient();
        }

        
    }

}
