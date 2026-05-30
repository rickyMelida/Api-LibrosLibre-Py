using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetRecentBooksHandler(
		IBookService _bookService
	) : IRequestHandler<GetRecentBooksQuery, ApiResponse<List<BookDTOResponse>>>
	{
		public async Task<ApiResponse<List<BookDTOResponse>>> Handle(GetRecentBooksQuery request, CancellationToken ct)
		{
			var result = await _bookService.GetRecentsBooks(request.Amount);
			return new ApiResponse<List<BookDTOResponse>>
			{
				StatusCode = 200,
				Message = "Libros recientes obtenidos exitosamente",
				Data = result
			};
		}
	}
}