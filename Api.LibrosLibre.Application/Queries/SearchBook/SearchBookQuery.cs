using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public record SearchBookQuery(string keyword) : IRequest<ApiResponse<List<BookDTOResponse>>>;
}