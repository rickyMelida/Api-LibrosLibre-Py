using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public class SetFavoriteBookHandler(
		IBookService _bookService
	) : IRequestHandler<SetFavoriteBookCommand, ApiResponse<int>>
	{
		public async Task<ApiResponse<int>> Handle(SetFavoriteBookCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookService.SetFavoriteBook(request.userId, request.bookId);
			return new ApiResponse<int>
			{
				StatusCode = 200,
				Message = "Libro favorito actualizado exitosamente",
				Data = result
			};
		}
	}
}