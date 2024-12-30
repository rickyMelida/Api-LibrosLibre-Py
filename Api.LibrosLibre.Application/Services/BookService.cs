using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }


        public Task<List<Book>> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetFeaturedBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetOthersBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetRecentsBooks()
        {
            throw new NotImplementedException();
        }

        public async Task<Book> SetBook(SetBookRequest bookRequest)
        {
            throw new NotImplementedException();
            /*var book = new Book 
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                Price = bookRequest.Price,
                State = bookRequest.State,
                TransactionType = bookRequest.TransactionType
            }
            await _bookRepository.CreateBook(book);
            await _unitOfWork.Save();
            
            return book;*/
        }
    }
}
