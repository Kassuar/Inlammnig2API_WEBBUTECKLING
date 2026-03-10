using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlammnig2API_WEBBUTECKLING.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            var result = _userService.Register(dto);
            if (result == null)
            {
                return BadRequest("Failed to register");
            }
            return Ok(result);

        }


        [HttpPost("Login")]

        public IActionResult Login([FromBody] LogonDTO dto)
        {
            var token = _userService.Logon(dto);

            if(token == null)
                return Unauthorized("Invalid email or password");

            return Ok(new {token=token });
        }

    }
}
