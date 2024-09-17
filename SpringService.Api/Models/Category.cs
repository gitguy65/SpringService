using System.ComponentModel.DataAnnotations.Schema;

namespace SpringService.Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } ="";
        public string Slug { get; set; } ="";
        [NotMapped]
        public IFormFile CategoryImage { get; set; }
        public string CategoryImageUrl { get; set; } = "";
        public string Description { get; set; } ="";
        public bool Status { get; set; }
    }   
}