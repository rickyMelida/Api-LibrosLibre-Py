using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetUserByUidHandler : IRequestHandler<GetUserByUidQuery, UserDTO>
	{
		private readonly IUserService _userService;

		public GetUserByUidHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<UserDTO> Handle(GetUserByUidQuery request, CancellationToken cancellationToken)
		{
			return await _userService.GetUserByUid(request.uid);
		}
	}
}