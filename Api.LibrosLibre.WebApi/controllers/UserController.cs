using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user")]
        public string GetUser()
        {
            return "User";
        }

        [HttpPost("set-user")]
        public ActionResult<User> SetUser(User user)
        {
            var result = _userService.CreateUser(user);
            if(result != null)
                return Ok(user);

            return BadRequest();
        }

    }
}