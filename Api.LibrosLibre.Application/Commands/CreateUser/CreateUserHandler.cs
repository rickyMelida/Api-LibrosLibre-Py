using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public class CreateUserHandler(IUserService _userService) : IRequestHandler<CreateUserCommand, UserDTO>
	{
		public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			return await _userService.CreateUser(request.user);
		}
	}
}