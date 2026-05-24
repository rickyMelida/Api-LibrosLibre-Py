using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public record CreateUserCommand(UserDTO user) : IRequest<UserDTO>;
}