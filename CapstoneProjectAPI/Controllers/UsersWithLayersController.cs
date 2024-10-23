using System.Collections.Generic;
using System.Threading.Tasks;
using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWithLayersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersWithLayersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/UsersWithLayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/UsersWithLayers/byusername/{username}
        [HttpGet("byusername/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/UsersWithLayers
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserByUsername), new { username = user.UserName }, user);
        }

        // PUT: api/UsersWithLayers/edit/{username}
        [HttpPut("edit/{username}")]
        public async Task<IActionResult> PutUserByUsername(string username, [FromBody] User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                await _userService.UpdateUserAsync(username, user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user profile.");
            }

            return NoContent();
        }
    }
}
