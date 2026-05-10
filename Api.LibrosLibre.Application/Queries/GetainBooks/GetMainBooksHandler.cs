using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetMainBooksHandler() : IRequestHandler<GetMainBooksQuery, List<ImageDTO>>
	{
		public async Task<List<ImageDTO>> Handle(GetMainBooksQuery request, CancellationToken ct)
		{
			return new List<ImageDTO>();	
		}
	} 
}