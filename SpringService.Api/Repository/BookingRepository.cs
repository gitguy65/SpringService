using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public bool BookingExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetUserBooking(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
