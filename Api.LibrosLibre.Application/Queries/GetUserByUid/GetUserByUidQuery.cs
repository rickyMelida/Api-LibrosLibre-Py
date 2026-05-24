using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record GetUserByUidQuery(string uid) : IRequest<UserDTO>;
}