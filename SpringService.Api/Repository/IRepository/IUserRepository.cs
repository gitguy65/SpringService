using SpringService.Api.Models;

namespace SpringService.Api.Repository.IRepository
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
