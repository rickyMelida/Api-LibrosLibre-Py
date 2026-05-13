using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetFavoriteBookHandler(
		IBookService _bookService
	) : IRequestHandler<GetFavoriteBookQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(GetFavoriteBookQuery request, CancellationToken ct)
		{
			return await _bookService.GetFavoritesBooks(request.userId);
		}
	}
}