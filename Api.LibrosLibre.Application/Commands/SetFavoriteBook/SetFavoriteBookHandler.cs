using MediatR;

namespace Api.LibrosLibre.Application.Commands
{
	public class SetFavoriteBookHandler : IRequestHandler<SetFavoriteBookCommand, int>
	{
		public Task<int> Handle(SetFavoriteBookCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}