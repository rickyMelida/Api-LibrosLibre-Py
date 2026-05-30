using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetBookByUserHandler(
		IBookService _bookService
	) : IRequestHandler<GetBookByUserQuery, ApiResponse<List<BookDTOResponse>>>
	{
		public async Task<ApiResponse<List<BookDTOResponse>>> Handle(GetBookByUserQuery request, CancellationToken ct)
		{
			var result = await _bookService.GetBooksByUser(request.userId);
			return new ApiResponse<List<BookDTOResponse>>
			{
				StatusCode = 200,
				Message = "Libros obtenidos exitosamente",
				Data = result
			};
		}
	}
}