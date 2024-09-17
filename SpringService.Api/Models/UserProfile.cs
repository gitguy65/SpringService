using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpringService.Api.Models
{
    public class UserProfile : IdentityUser
    {
        public string Slug { get; set; } ="";
        public string FirstName { get; set; } ="";
        public string LastName { get; set; } ="";
        public string Email { get; set; } = "";
        [NotMapped]
        public IFormFile ProfilePicture { get; set; }
        public string ProfilePictureUrl { get; set; } ="";
        public string Password { get; set; } ="";
        public string ConfirmPassword { get; set; } ="";
        public double Balance { get; set; }
        public string Address { get; set; } ="";
        public bool IsVerified { get; set; }
        public string Designation { get; set; } ="";
        public string Details { get; set; } ="";
        public string Experience { get; set; } ="";
        public string Qualification { get; set; } ="";
        public string[] Social { get; set; } = [];
        public ICollection<Review>? GivenReviews { get; set; }
        public ICollection<Review>? ReceivedReviews { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<History>? Histories { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Service>? Services { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public bool RecieveNotifications { get; set; }
        public bool IsDeleted { get; set; }
    }
}