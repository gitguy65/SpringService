using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool CategoryExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
