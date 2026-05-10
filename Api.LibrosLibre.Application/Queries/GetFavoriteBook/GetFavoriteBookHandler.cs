using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetFavoriteBookHandler() : IRequestHandler<GetFavoriteBookQuery, BookDTOResponse>
	{
		public async Task<BookDTOResponse> Handle(GetFavoriteBookQuery request, CancellationToken ct)
		{
			return new BookDTOResponse();	
		}
	}
}