using SpringApi.Data;
using SpringApi.Model;
using SpringApi.Repository.IRepository;

namespace SpringApi.Repository
{
    public class UserRepository(ApplicationDbContext context) : BaseRepository(context), IUserRepository
    {
        private new readonly ApplicationDbContext context = context;
        public bool CreateUser(UserProfile user)
        {
            context.Add(user);
            return Save();
        }

        public bool DeleteUser(UserProfile user)
        {
            context.Remove(user);
            return Save();
        }

        public UserProfile? GetUser(string Id) => context.UserProfiles.Where(u => u.Slug == Id).FirstOrDefault() ?? null;

        public IEnumerable<UserProfile> GetUsers() => [.. context.UserProfiles];

        public bool UpdateUser(UserProfile user)
        {
            context.Update(user);
            return Save();
        }

        public bool UserExists(UserProfile user)
        {
            return context.Users.Any(u => u.Id == user.Id);
        }

        // private bool Save()
        // {
        //     int saved = context.SaveChanges();
        //     return saved > 0;
        // }
    }
}
