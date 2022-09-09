using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.Interfaces.Services;

namespace PeopleActz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<Result<IEnumerable<UserResponse>>> GetAllUsers()
        {
            return await _userService.GetAll();

        }
        [HttpGet("GetById")]
        public async Task<IActionResult>GetUserById(string id)
        {
            var user = await _userService.GetById(id);
            return StatusCode(user.StatusCode, user.Payload);

            
        }
    }
}
