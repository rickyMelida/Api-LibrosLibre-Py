using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record GetBookDetailsQuery(int Id) : IRequest<BookDTOResponse>;	
}