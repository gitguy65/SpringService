using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string ServiceCategory { get; set; }
        public string ServiceUserId { get; set; }
        public AppUser ServiceUser { get; set; }
        public string ServiceProviderId { get; set; }
        public AppUser ServiceProvider { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public double Star { get; set; }
    }
}
