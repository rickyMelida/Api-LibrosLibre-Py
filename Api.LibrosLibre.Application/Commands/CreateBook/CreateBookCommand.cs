using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public record CreateBookCommand(BookDTORequest bookRequest) : IRequest<ApiResponse<int>>;
}