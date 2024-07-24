using SpringService.Api.Models;

namespace SpringService.Api.Repository.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<AppUser> GetUsers();
        AppUser GetUser(string slug);
        bool CreateUser(AppUser user);
        bool UpdateUser(AppUser user);
        bool DeleteUser(AppUser user);
        bool UserExists(AppUser user);
    }
}
