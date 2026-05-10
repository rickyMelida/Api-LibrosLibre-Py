using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public record CreateBookCommand(BookDTORequest bookRequest) : IRequest<int>;
}