using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
    {
        private new readonly ApplicationDbContext context = context;
        public bool CreateUser(AppUser user)
        {
            context.Add(user);
            return Save();
        }

        public bool DeleteUser(AppUser user)
        {
            context.Remove(user);
            return Save();
        }

        public AppUser? GetUser(string Id) => context.AppUsers.Where(u => u.Id == Id).FirstOrDefault() ?? null;

        public IEnumerable<AppUser> GetUsers() => [.. context.AppUsers];

        public bool UpdateUser(AppUser user)
        {
            context.Update(user);
            return Save();
        }

        public bool UserExists(AppUser user)
        {
            return context.Users.Any(u => u.Id == user.Id);
        }

        private bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }
    }
}
