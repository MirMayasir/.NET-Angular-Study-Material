using NUnit.Framework;
using Moq;
using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Repositery;
using CapstoneProjectAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneProjectAPI.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            // Create a mock of IUserRepository
            _userRepositoryMock = new Mock<IUserRepository>();

            // Instantiate UserService with the mocked IUserRepository
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllUsersAsync_ShouldReturnListOfUsers()
        {
            // Arrange
            var mockUsers = new List<User>
            {
                new User { UserId = 1, UserName = "testuser1", Email = "testuser1@example.com" },
                new User { UserId = 2, UserName = "testuser2", Email = "testuser2@example.com" }
            };

            _userRepositoryMock
                .Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(mockUsers);

            // Act
            var users = await _userService.GetAllUsersAsync();

            // Assert
            Assert.AreEqual(2, users.Count());
            Assert.AreEqual("testuser1", users.First().UserName);
        }

        [Test]
        public async Task GetUserByUsernameAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var mockUser = new User { UserId = 1, UserName = "testuser", Email = "testuser@example.com" };

            _userRepositoryMock
                .Setup(repo => repo.GetUserByUsernameAsync("testuser"))
                .ReturnsAsync(mockUser);

            // Act
            var user = await _userService.GetUserByUsernameAsync("testuser");

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("testuser", user.UserName);
        }

        [Test]
        public async Task GetUserByUsernameAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            _userRepositoryMock
                .Setup(repo => repo.GetUserByUsernameAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            // Act
            var user = await _userService.GetUserByUsernameAsync("nonexistentuser");

            // Assert
            Assert.IsNull(user);
        }

        [Test]
        public async Task AddUserAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var newUser = new User { UserName = "newuser", Email = "newuser@example.com" };

            _userRepositoryMock
                .Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            await _userService.AddUserAsync(newUser);

            // Assert
            _userRepositoryMock.Verify(repo => repo.AddUserAsync(It.Is<User>(u => u.UserName == "newuser")), Times.Once);
        }

        [Test]
        public async Task UpdateUserAsync_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock
                .Setup(repo => repo.GetUserByUsernameAsync("nonexistentuser"))
                .ReturnsAsync((User)null);

            var updatedUser = new User { UserName = "nonexistentuser", Email = "updated@example.com" };

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _userService.UpdateUserAsync("nonexistentuser", updatedUser));
            Assert.AreEqual("User not found.", ex.Message);
        }

        [Test]
        public async Task UpdateUserAsync_ShouldUpdateUser_WhenUserExists()
        {
            // Arrange
            var existingUser = new User { UserId = 1, UserName = "existinguser", Email = "oldemail@example.com", Password = "oldpassword" };

            _userRepositoryMock
                .Setup(repo => repo.GetUserByUsernameAsync("existinguser"))
                .ReturnsAsync(existingUser);

            _userRepositoryMock
                .Setup(repo => repo.UpdateUserAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            var updatedUser = new User { Email = "newemail@example.com", Password = "newpassword" };

            // Act
            await _userService.UpdateUserAsync("existinguser", updatedUser);

            // Assert
            _userRepositoryMock.Verify(repo => repo.UpdateUserAsync(It.Is<User>(u => u.Email == "newemail@example.com" && u.Password == "newpassword")), Times.Once);
        }
    }
}
