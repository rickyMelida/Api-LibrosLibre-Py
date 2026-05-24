using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public record SetFavoriteBookCommand(int userId, int bookId) : IRequest<int>;
}