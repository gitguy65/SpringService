using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ServiceId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } //might change this to char
        public double Charge { get; set; }
        public double Commission { get; set; }
        public string Details { get; set; }
        public string Type { get; set; } 
    }
}
