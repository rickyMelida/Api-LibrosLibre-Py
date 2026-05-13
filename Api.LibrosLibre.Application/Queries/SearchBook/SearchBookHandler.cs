using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class SearchBookHandler(
		IBookService _bookService
	) : IRequestHandler<SearchBookQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(SearchBookQuery request, CancellationToken ct)
		{
			return await _bookService.SearchBook(request.keyword);
		}
	}
}