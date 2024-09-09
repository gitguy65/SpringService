using SpringApi.Data;
using SpringApi.Model;
using SpringApi.Repository.IRepository;

namespace SpringApi.Repository
{
    public class CategoryRepository(ApplicationDbContext context) : BaseRepository(context), ICategoryRepository
    {
        private new readonly ApplicationDbContext context = context;

        public bool CategoryExists(int id) => context.Categories.Any(c => c.Id == id);

        public bool CreateCategory(Category category)
        {
            context.Add(category);
            return Save();
        }

        public bool DeleteCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(b => b.Id == id);
            if(category != null)
            {
                context.Remove(entity: category.Id);
            }
            return Save();
        }

        public IEnumerable<Category> FetchAll() => [.. context.Categories];

        public Category GetCategory(int id) => context.Categories.Where(c => c.Id == id).FirstOrDefault() ?? null;

        public bool UpdateCategory(Category category)
        {
            context.Update(category);
            return Save();
        }
    }
}
