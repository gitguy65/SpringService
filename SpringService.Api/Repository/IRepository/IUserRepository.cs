using SpringService.Api.Models;

namespace SpringService.Api.Repository.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string slug);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool UserExists(User user);
    }
}
