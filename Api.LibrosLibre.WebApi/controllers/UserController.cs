using Api.LibrosLibre.Application.Commands;
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Application.Queries;
using Api.LibrosLibre.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-user-by-uid")]
        public async Task<ActionResult<ApiResponse<UserDTO>>> GetUser([FromQuery] string uid)
        {
			var user = await _mediator.Send(new GetUserByUidQuery(uid));
			
			return Ok(user);
        }

        [HttpPost("set-user")]
        public async Task<ActionResult<ApiResponse<UserDTO>>> SetUser([FromBody] CreateUserCommand user)
        {
           var createdUser = await _mediator.Send(user);

		   return Created(string.Empty, createdUser);
        }

    }
}