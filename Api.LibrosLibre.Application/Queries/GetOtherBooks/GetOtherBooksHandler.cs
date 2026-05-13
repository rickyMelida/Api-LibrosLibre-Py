using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetOtherBooksHandler(
		IBookService _bookService
	) : IRequestHandler<GetOtherBooksQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(GetOtherBooksQuery request, CancellationToken ct)
		{
			return await _bookService.GetOthersBooks(request.amount);
		}
	}
}