using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        [HttpGet("get-user")]
        public string GetUser()
        {
            return "User";
        }

    }
}