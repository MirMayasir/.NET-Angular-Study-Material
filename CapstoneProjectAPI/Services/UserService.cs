using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Repositery;

namespace CapstoneProjectAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(string username, User user)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // Update properties only if they are not null
            existingUser.Email = user.Email ?? existingUser.Email;
            existingUser.Password = user.Password ?? existingUser.Password;
            // Update other properties as needed

            await _userRepository.UpdateUserAsync(existingUser);
        }
    }
}
