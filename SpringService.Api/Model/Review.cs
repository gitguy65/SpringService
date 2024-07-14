using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string ServiceCategory { get; set; }
        public int ServiceUserId { get; set; }
        public User ServiceUser { get; set; }
        public int ServiceProviderId { get; set; }
        public User ServiceProvider { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public double Star { get; set; }
    }
}
