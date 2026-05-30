using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetOtherBooksHandler(
		IBookService _bookService
	) : IRequestHandler<GetOtherBooksQuery, ApiResponse<List<BookDTOResponse>>>
	{
		public async Task<ApiResponse<List<BookDTOResponse>>> Handle(GetOtherBooksQuery request, CancellationToken ct)
		{
			var result = await _bookService.GetOthersBooks(request.amount);
			return new ApiResponse<List<BookDTOResponse>>
			{
				StatusCode = 200,
				Message = "Libros otros obtenidos exitosamente",
				Data = result
			};
		}
	}
}