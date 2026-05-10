using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetBookDetailsHandler() : IRequestHandler<GetBookDetailsQuery, BookDTOResponse>
	{
		public async Task<BookDTOResponse> Handle(GetBookDetailsQuery request, CancellationToken ct)
		{
			return new BookDTOResponse();
		}
	}
}