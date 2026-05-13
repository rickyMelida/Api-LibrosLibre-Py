using Api.LibrosLibre.Application.DTOs;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetMainBooksHandler(
		IImagesService _bookImagesService
	) : IRequestHandler<GetMainBooksQuery, List<ImageDTO>>
	{
		public async Task<List<ImageDTO>> Handle(GetMainBooksQuery request, CancellationToken ct)
		{
			return await _bookImagesService.GetRelevantBookImages();
		}
	} 
}