using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService) =>
            _userService = userService;

            
        [HttpPost("login")]
        public string Login(string username, string password)
        {
            if(username == "ricardo" && password == "1234")
                return "Login Successful";
            else
                return "Login Failed";
        }

        [HttpPost("register")]
        public async Task<IActionResult<User>> Register(User user)
        {
            var registerUser = await _userService.CreateUser(user);
            if(registerUser.Result)
                return Ok(user);

            return BadRequest();
        }


    }

}