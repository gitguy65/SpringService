using SpringService.Api.Models;

namespace SpringService.Api.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> FetchAll();
        bool CategoryExists(int id);
        Category GetCategory(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int category); 
    }
}
