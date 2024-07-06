using SpringService.Api.Models;

namespace SpringService.Api.Model.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Slug { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Designation { get; set; }
        public string Details { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; } 
        public string Password { get; set; }
        public string Social { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<History> Histories { get; set; }
    }
}
