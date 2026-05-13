using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetBookByUserHandler(
		IBookService _bookService
	) : IRequestHandler<GetBookByUserQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(GetBookByUserQuery request, CancellationToken ct)
		{
			return await _bookService.GetBooksByUser(request.userId);
		}
	}
}