using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public record SetFavoriteBookCommand(int userId, int bookId) : IRequest<ApiResponse<int>>;
}