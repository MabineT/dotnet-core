using System.Threading.Tasks;
using causal.api.Data.TransferObjects;
using causal.api.Helpers;
using causal.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace causal.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly IConfiguration _configuration;

        public UsersController(IHelper helper, IConfiguration configuration)
        {
            _helper = helper;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> AddUser(DTOUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("incorrect model state");
            }

            user.Name = user.Name.ToLower();

            var userToStore = new User
            {
                Name = user.Name,
                PassportNumber = user.PassportNumber,
                IdentityNumber = user.IdentityNumber,
                Active = true
            };

            var created = await _helper.AddUserAsync(userToStore);

            return Created("Created successfully", created);
        }



        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(DTOUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("incorrect model state");
            }

            user.Name = user.Name.ToLower();

            var userToStore = new User
            {
                Name = user.Name,
                PassportNumber = user.PassportNumber,
                IdentityNumber = user.IdentityNumber,
                Active = true
            };

            var created = await _helper.AddUserAsync(userToStore);

            return Created("Created successfully", created);
        }

        [AllowAnonymous]
        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, DTOUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("incorrect model state");
            }

            user.Name = user.Name.ToLower();

            var userToStore = new User
            {
                Name = user.Name,
                PassportNumber = user.PassportNumber,
                IdentityNumber = user.IdentityNumber,
                // active = true
            };

            var updated = await _helper.UpdateUserAsync(userId, userToStore);
            return Accepted(updated);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var created = await _helper.GetAllUsers();
            return Ok(created);
        }


        [AllowAnonymous]
        [HttpDelete("remove/{userId}")]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            var removedUser = await _helper.RemoveUserAsync(userId);

            if (!(removedUser == null))
            {
                return Accepted(removedUser);
            }
            return NotFound("User not found");
        }
    }
}