namespace SpringService.Models
{
    public class Review
    { 
        public int Id { get; set; }
        public string ServiceCategory { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public double Star { get; set; }
    }
}
