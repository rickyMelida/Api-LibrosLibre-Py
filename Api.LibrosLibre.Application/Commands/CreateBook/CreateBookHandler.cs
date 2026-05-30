using Api.LibrosLibre.Domain.Common;
using MediatR;

namespace Api.LibrosLibre.Application.Commands
{	public class CreateBookHandler(IBookService _bookService) : IRequestHandler<CreateBookCommand, ApiResponse<int>>
	{
		public async Task<ApiResponse<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookService.SetNewBook(request.bookRequest);
			return new ApiResponse<int>
			{
				StatusCode = 200,
				Message = "Libro agregado exitosamente",
				Data = result
			};
		}
	}	
}