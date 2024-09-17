namespace SpringService.Api.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string UserId { get; set; } ="";
        public UserProfile UserProfile { get; set; }
        public string WeekName { get; set; } ="";
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
    }
}