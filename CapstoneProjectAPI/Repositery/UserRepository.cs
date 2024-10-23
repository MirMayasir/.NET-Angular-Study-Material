using CapstoneProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectAPI.Repositery
{
    public class UserRepository : IUserRepository
    {
        private readonly CapstoneProjectContext _context;

        public UserRepository(CapstoneProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(e => e.UserId == id);
        }
    }
}
