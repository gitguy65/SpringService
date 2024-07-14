namespace SpringService.Api.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
