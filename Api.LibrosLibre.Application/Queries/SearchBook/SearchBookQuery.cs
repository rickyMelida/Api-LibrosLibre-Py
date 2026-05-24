using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record SearchBookQuery(string keyword) : IRequest<List<BookDTOResponse>>;
}