namespace SpringApi.Model
{
    public class History
    {
        public int Id { get; set; }
        public string UserId { get; set; } ="";
        public UserProfile UserProfile { get; set; }
        public int ServiceId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } ="";
        public double Charge { get; set; }
        public double Commission { get; set; }
        public string Details { get; set; } ="";
        public string Type { get; set; } ="";
    }
}