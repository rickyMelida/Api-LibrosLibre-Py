using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record GetFavoriteBookQuery(int userId) : IRequest<BookDTOResponse>;
}