using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record GetBookByUserQuery(int userId) : IRequest<List<BookDTOResponse>>;
}