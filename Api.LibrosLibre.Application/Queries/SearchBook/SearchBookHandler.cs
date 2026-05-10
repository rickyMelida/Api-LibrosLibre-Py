using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class SearchBookHandler() : IRequestHandler<SearchBookQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(SearchBookQuery request, CancellationToken ct)
		{
			return new List<BookDTOResponse>();	
		}
	}
}