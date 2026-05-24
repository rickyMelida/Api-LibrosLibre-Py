using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record GetFeaturedBooksQuery(int amount) : IRequest<List<BookDTOResponse>>;
}