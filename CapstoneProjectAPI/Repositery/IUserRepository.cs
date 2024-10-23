using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Repositery
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<bool> UserExistsAsync(int id);
    }
}
