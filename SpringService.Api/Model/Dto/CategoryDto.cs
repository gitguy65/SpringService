namespace SpringService.Api.Model.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
