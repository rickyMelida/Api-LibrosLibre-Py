using System.Threading.Tasks;
using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<string>> GetUser()
        {
            var bearerToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(bearerToken) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;
            var payload = jsonToken?.Payload;

            if(payload == null)
                return BadRequest();

            var user = await _userService.GetUserByMail(payload["email"]);
            if(user == null)
                return BadRequest();

            return Ok(user);
        }

        [HttpPost("set-user")]
        [Authorize]
        public ActionResult<User> SetUser(User user)
        {
            var result = _userService.CreateUser(user);
            if(result != null)
                return Ok(user);

            return BadRequest();
        }

    }
}