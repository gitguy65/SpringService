using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class CategoryRepository(ApplicationDbContext context) : BaseRepository(context), ICategoryRepository
    {
        private new readonly ApplicationDbContext context = context;

        public bool CategoryExists(int id) => context.Cateogries.Any(c => c.Id == id);

        public bool CreateCategory(Category category)
        {
            context.Add(category);
            return Save();
        }

        public bool DeleteCategory(int id)
        {
            var category = context.Cateogries.FirstOrDefault(b => b.Id == id);
            context.Remove(entity: category.Id);
            return Save();
        }

        public IEnumerable<Category> FetchAll() => [.. context.Cateogries];

        public Category GetCategory(int id) => context.Cateogries.Where(c => c.Id == id).FirstOrDefault() ?? null;

        public bool UpdateCategory(Category category)
        {
            context.Update(category);
            return Save();
        }
    }
}
