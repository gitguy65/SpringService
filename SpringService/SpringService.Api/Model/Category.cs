using System.ComponentModel.DataAnnotations;

namespace SpringService.Api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
