namespace SpringService.Api.Models
{
    public class Review
    { 
        public int Id { get; set; }
        public string ServiceCategory { get; set; }
        public User UserId { get; set; }
        public string Message { get; set; }
        public double Star { get; set; }
    }
}
