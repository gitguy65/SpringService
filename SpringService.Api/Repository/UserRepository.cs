using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
{
    public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
    {
        private new readonly ApplicationDbContext context = context;
        public bool CreateUser(User user)
        {
            context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            context.Remove(user);
            return Save();
        }

        public User GetUser(string slug)
        {
            return context.Users.Where(u  => u.Slug == slug).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            context.Update(user);
            return Save();
        }

        public bool UserExists(User user)
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
