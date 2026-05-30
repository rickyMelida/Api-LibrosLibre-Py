using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class SearchBookHandler(
		IBookService _bookService
	) : IRequestHandler<SearchBookQuery, ApiResponse<List<BookDTOResponse>>>
	{
		public async Task<ApiResponse<List<BookDTOResponse>>> Handle(SearchBookQuery request, CancellationToken ct)
		{
			var result = await _bookService.SearchBook(request.keyword);
			return new ApiResponse<List<BookDTOResponse>>
			{
				StatusCode = 200,
				Message = "Libros encontrados exitosamente",
				Data = result
			};
		}
	}
}