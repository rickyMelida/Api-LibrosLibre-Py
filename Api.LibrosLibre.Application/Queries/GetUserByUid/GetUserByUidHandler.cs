using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetUserByUidHandler : IRequestHandler<GetUserByUidQuery, ApiResponse<UserDTO>>
	{
		private readonly IUserService _userService;

		public GetUserByUidHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<ApiResponse<UserDTO>> Handle(GetUserByUidQuery request, CancellationToken cancellationToken)
		{
			var result = await _userService.GetUserByUid(request.uid);
			return new ApiResponse<UserDTO>
			{
				StatusCode = 200,
				Message = "Usuario obtenido exitosamente",
				Data = result
			};
		}
	}
}