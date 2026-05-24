using MediatR;

namespace Api.LibrosLibre.Application.Commands
{	public class CreateBookHandler(IBookService _bookService) : IRequestHandler<CreateBookCommand, int>
	{
		public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			return await _bookService.SetNewBook(request.bookRequest);
		}
	}	
}