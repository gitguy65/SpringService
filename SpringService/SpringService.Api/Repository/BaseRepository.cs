using SpringService.Api.Data;

namespace SpringService.Api.Repository
{
    public abstract class BaseRepository(ApplicationDbContext context)
    {
        protected readonly ApplicationDbContext context = context;

        public bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }
    }

}
