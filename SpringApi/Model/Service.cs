namespace SpringApi.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string Description { get; set; } ="";
        public string UserId { get; set; } ="";
        public UserProfile UserProfile { get; set; }
    }
}