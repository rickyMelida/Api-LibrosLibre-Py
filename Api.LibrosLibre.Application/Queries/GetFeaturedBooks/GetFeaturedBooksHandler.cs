using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetFeaturedBooksHandler(
		IBookService _bookService
	) : IRequestHandler<GetFeaturedBooksQuery, ApiResponse<List<BookDTOResponse>>>
	{
		public async Task<ApiResponse<List<BookDTOResponse>>> Handle(GetFeaturedBooksQuery request, CancellationToken ct)
		{
			var result = await _bookService.GetFeaturedBooks(request.amount);
			return new ApiResponse<List<BookDTOResponse>>
			{
				StatusCode = 200,
				Message = "Libros destacados obtenidos exitosamente",
				Data = result
			};
		}
	}
}