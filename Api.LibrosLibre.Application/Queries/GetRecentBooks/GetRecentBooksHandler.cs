using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetRecentBooksHandler(
		IBookService _bookService
	) : IRequestHandler<GetRecentBooksQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(GetRecentBooksQuery request, CancellationToken ct)
		{
			return await _bookService.GetRecentsBooks(request.Amount);
		}
	}
}