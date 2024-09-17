using SpringService.Api.Data;
using SpringService.Api.Models;
using SpringService.Api.Repository.IRepository;

namespace SpringService.Api.Repository
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

        //public UserProfile? GetUser(string Id) => context.UserProfiles.Where(u => u.Slug == Id).FirstOrDefault() ?? null;
        public UserProfile? GetUser(string Id)
        {
           throw new NotImplementedException();
        }

        // public IEnumerable<UserProfile> GetUsers() => [.. context.UserProfiles];
        public IEnumerable<UserProfile> GetUsers()
        {
            throw new NotImplementedException();
        }

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
