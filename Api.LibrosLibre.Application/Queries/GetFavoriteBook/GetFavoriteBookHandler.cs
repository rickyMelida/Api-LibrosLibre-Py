using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetFavoriteBookHandler(
		IBookService _bookService
	) : IRequestHandler<GetFavoriteBookQuery, ApiResponse<List<BookDTOResponse>>>
	{
		public async Task<ApiResponse<List<BookDTOResponse>>> Handle(GetFavoriteBookQuery request, CancellationToken ct)
		{
			var result = await _bookService.GetFavoritesBooks(request.userId);
			return new ApiResponse<List<BookDTOResponse>>
			{
				StatusCode = 200,
				Message = "Libros favoritos obtenidos exitosamente",
				Data = result
			};
		}
	}
}