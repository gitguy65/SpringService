using SpringService.Api.Models;

namespace SpringService.Api.Repository.IRepository
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetUserBooking(UserProfile user);
        Booking GetBooking(int id);
        bool CreateBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int id); 
        bool BookingExists(int id); 
    }
}
