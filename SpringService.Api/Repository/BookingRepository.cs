using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class BookingRepository(ApplicationDbContext context) : BaseRepository(context), IBookingRepository
    {
        private new readonly ApplicationDbContext context = context;

        public bool BookingExists(int id)
        {
            return context.Bookings.Any(b => b.Id == id);
        }

        public bool CreateBooking(Booking booking)
        {
            context.Add(booking);
            return Save();
        }

        public bool DeleteBooking(int id)
        {
            var booking = context.Bookings.FirstOrDefault(b => b.Id == id);
            if (BookingExists(id))
            {
                context.Remove(booking);
                return Save();
            }
            return false; 
        }

        public IEnumerable<Booking> GetAllBookings() => context.Bookings.ToList();

        public Booking GetBooking(int id) => context.Bookings.Where(b => b.Id == id).FirstOrDefault();

        public IEnumerable<Booking> GetUserBooking(User user) => context.Bookings.Where(b => b.Id == user.Id).ToList();

        public bool UpdateBooking(Booking booking)
        {
            context.Update(booking);
            return Save();
        }

        /*private bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }*/
    }
}
