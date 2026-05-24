using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetBookDetailsHandler(
		IBookService _bookService
		) : IRequestHandler<GetBookDetailsQuery, BookDTOResponse>
	{
		public async Task<BookDTOResponse> Handle(GetBookDetailsQuery request, CancellationToken ct)
		{
			return await _bookService.GetBook(request.Id);
		}
	}
}