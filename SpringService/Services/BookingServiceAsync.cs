using SpringService.Models;
using SpringService.Services.IService;
using System.Net.Http.Json; 

namespace SpringService.Services
{
    public class BookingServiceAsync: IBookingService
    {
        private readonly HttpClient httpClient;
        List<Booking> bookings = [];

        public BookingServiceAsync()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Booking>> GetBookings()
        {
            if (bookings.Count > 0)
                return bookings;

            string url;

#if DEBUG
            url = "http://link-to-api/api/";
#else
            url = "https://link-to-api/api/";
#endif

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                bookings = await response.Content.ReadFromJsonAsync<List<Booking>>();
            }
            
            return bookings;
        }

    }
}
