using KooBits.MicroServices.UserServices.Models;

namespace KooBits.MicroServices.UserServices.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
    }
}

 

