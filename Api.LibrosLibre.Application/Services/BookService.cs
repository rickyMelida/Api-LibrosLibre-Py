using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUserBookRepository _userBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IImageRepository imageRepository, IUserBookRepository userBookRepository, IUnitOfWork unitOfWork) =>
            (_bookRepository, _imageRepository, _userBookRepository, _unitOfWork) = 
            (bookRepository, imageRepository, userBookRepository, unitOfWork);

        public Task<List<Book>> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookRequest>> GetFeaturedBooks(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookRequest>> GetOthersBooks(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookRequest>> GetRecentsBooks(int amount)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> SetBook(BookRequest bookRequest)
        {
            int bookId = await _bookRepository.GetLastId() + 1;
            Book book = new Book()
            {
                Id = bookId,
                Author = bookRequest.Author,
                Available = true,
                LitleDescription = bookRequest.Description,
                Title = bookRequest.Title,
                OtherDetails = bookRequest.OtherDetail ?? "",
                Price = bookRequest.Price,
                State = bookRequest.State,
                TransactionType = bookRequest.TransactionType,
                UploadDate = DateTime.UtcNow,
                Year = bookRequest.Year ?? ""
            };
            
            await _bookRepository.CreateBook(book);
            await _unitOfWork.Save();

            int imageId = await _imageRepository.GetLastId() + 1;
            Image image = new Image()
            {
                Id = imageId,
                BookId = book.Id,
                Description = "Book Image",
                Picture = bookRequest.Images[0]
            };
            
            await _imageRepository.CreateImage(image);
            await _unitOfWork.Save();

            int userBookId = await _userBookRepository.GetLastId() + 1;
            UserBook userBook = new UserBook()
            {
                Id = userBookId,
                User = bookRequest.User,
                Book = book.Id
            };

            await _userBookRepository.CreateUserBook(userBook);
            await _unitOfWork.Save();

            return book;

        }
    }
}
