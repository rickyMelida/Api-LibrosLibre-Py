using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record GetMainBooksQuery() : IRequest<List<ImageDTO>>;
}