using Api.LibrosLibre.Application.Commands;
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<UserDTO>> GetUser([FromQuery] string uid)
        {
			var user = await _mediator.Send(new GetUserByUidQuery(uid));
            
			if(user == null)
				return NotFound();
			
			return Ok(user);
        }

        [HttpPost("set-user")]
        public async Task<ActionResult<UserDTO>> SetUser([FromBody] CreateUserCommand user)
        {
           var createdUser = await _mediator.Send(user);
		   
		   return Created("User Created Successfully", createdUser);
        }

    }
}