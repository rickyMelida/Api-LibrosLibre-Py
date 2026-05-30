using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Queries
{
	public class GetMainBooksHandler(
		IImagesService _bookImagesService
	) : IRequestHandler<GetMainBooksQuery, ApiResponse<List<ImageDTO>>>
	{
		public async Task<ApiResponse<List<ImageDTO>>> Handle(GetMainBooksQuery request, CancellationToken ct)
		{
			var result = await _bookImagesService.GetRelevantBookImages();
			return new ApiResponse<List<ImageDTO>>
			{
				StatusCode = 200,
				Message = "Imágenes de libros principales obtenidas exitosamente",
				Data = result
			};
		}
	} 
}