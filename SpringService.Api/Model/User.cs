using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public double Balance { get; set; } 
        public string Address { get; set; }
        public string Image { get; set; }
        public string? Designation { get; set; }
        public string? Details { get; set; }
        public string? Experience { get; set; }
        public string? Qualification { get; set; }
        public bool IsVerified { get; set; } 
        public string Social { get; set; }
        public ICollection<Review>? GivenReviews { get; set; }
        public ICollection<Review>? ReceivedReviews { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<History>? Histories { get; set; }
    }
}
