using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetFeaturedBooksHandler() : IRequestHandler<GetFeaturedBooksQuery, List<BookDTOResponse>>
	{
		public async Task<List<BookDTOResponse>> Handle(GetFeaturedBooksQuery request, CancellationToken ct)
		{
			return new List<BookDTOResponse>();	
		}
	}
}