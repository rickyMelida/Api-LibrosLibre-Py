using MediatR;

namespace Api.LibrosLibre.Application.Commands
		{
	public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
	{
		public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}	
}