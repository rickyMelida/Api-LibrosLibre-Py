using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public class CreateUserHandler(IUserService _userService) : IRequestHandler<CreateUserCommand, ApiResponse<UserDTO>>
	{
		public async Task<ApiResponse<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var result = await _userService.CreateUser(request.user);
			return new ApiResponse<UserDTO>
			{
				StatusCode = 200,
				Message = "Usuario creado exitosamente",
				Data = result
			};
		}
	}
}