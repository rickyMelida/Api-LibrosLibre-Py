using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetOtherBooksHandler() : IRequestHandler<GetOtherBooksQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(GetOtherBooksQuery request, CancellationToken ct)
		{
			return new List<BookDTOResponse>();	
		}
	}
}