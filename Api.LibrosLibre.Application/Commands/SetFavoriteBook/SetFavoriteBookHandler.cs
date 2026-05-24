using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public class SetFavoriteBookHandler(
		IBookService _bookService
	) : IRequestHandler<SetFavoriteBookCommand, int>
	{
		public async Task<int> Handle(SetFavoriteBookCommand request, CancellationToken cancellationToken)
		{
			return await _bookService.SetFavoriteBook(request.userId, request.bookId);
		}
	}
}