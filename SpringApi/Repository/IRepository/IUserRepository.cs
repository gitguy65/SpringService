using SpringApi.Model;

namespace SpringApi.Repository.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<UserProfile> GetUsers();
        UserProfile GetUser(string slug);
        bool CreateUser(UserProfile user);
        bool UpdateUser(UserProfile user);
        bool DeleteUser(UserProfile user);
        bool UserExists(UserProfile user);
    }
}
