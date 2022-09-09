using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleActz.Application.DTOs.Requests.AppUser;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.Implementation.ServiceManagers;
using PeopleActz.Application.Interfaces.Services;

namespace PeopleActz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest userForRegistration)
        {
            var result = await _service.Register(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ResponseLogin>> Login([FromBody] LoginRequest user)
        {
            var loginProcess = await _service.Login(user);
            if (loginProcess.IsSuccessful)
            {
                return StatusCode(loginProcess.StatusCode, loginProcess.Payload);
            }

            return StatusCode(
                    loginProcess.StatusCode,
                    new ResponseLogin
                    {
                        IsLoginSuccessful = loginProcess.IsSuccessful,
                        ErrorMessage = loginProcess.Info
                    }
                );
        }

        
    }
}
