using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetBookDetailsHandler(
		IBookService _bookService
		) : IRequestHandler<GetBookDetailsQuery, ApiResponse<BookDTOResponse>>
	{
		public async Task<ApiResponse<BookDTOResponse>> Handle(GetBookDetailsQuery request, CancellationToken ct)
		{
			var result = await _bookService.GetBook(request.Id);
			return new ApiResponse<BookDTOResponse>
			{
				StatusCode = 200,
				Message = "Libro obtenido exitosamente",
				Data = result
			};
		}
	}
}