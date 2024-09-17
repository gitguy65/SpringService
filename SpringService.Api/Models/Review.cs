namespace SpringService.Api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ServiceCategory { get; set; } ="";
        public string ServiceUserId { get; set; } ="";
        public UserProfile ServiceUser { get; set; }
        public string ServiceProviderId { get; set; } ="";
        public UserProfile ServiceProvider { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; } ="";
        public double Star { get; set; }
    }
}