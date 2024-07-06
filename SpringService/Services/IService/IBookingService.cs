using SpringService.Models;

namespace SpringService.Services.IService
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings();
    }
}
