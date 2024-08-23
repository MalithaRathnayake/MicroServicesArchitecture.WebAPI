using KooBits.MicroServices.UserServices.Interfaces;
using KooBits.MicroServices.UserServices.Models; 
using Microsoft.EntityFrameworkCore;

namespace KooBits.MicroServices.UserServices.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserDBContext _context;

        public UserRepository(UserDBContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
