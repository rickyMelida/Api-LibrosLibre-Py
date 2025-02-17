using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImagesService  _bookImagesService; 
        private readonly IUserBookService _userBookService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository,
                           IImagesService bookImagesService,
                           IUserBookService userBookService,
                           IUserService userService,
                           IUnitOfWork unitOfWork) =>
            (_bookRepository, _bookImagesService, _userBookService,_userService, _unitOfWork) =
            (bookRepository, bookImagesService, userBookService, userService, unitOfWork);

        public async Task<BookDTOResponse> GetBook(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            var image = await _bookImagesService.GetImagesByBookId(book.Id);
            var userBook = await _userBookService.GetImagesByBookId(book.Id);
            var user = await _userService.GetUserById(userBook.User);

            return new BookDTOResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                State = book.State,
                TransactionType = book.TransactionType,
                Images = image.Select(e => Convert.ToBase64String(e.Picture)).ToList(),
                Description = book.LitleDescription,
                UserName = user.Name
            };
        }

        public Task<List<BookDTOResponse>> GetFeaturedBooks(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDTOResponse>> GetOthersBooks(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDTOResponse>> GetRecentsBooks(int amount)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> SetNewBook(BookDTORequest bookRequest)
        {
            Book book = await SetBook(bookRequest);

            await _bookImagesService.SetImages(bookRequest, book.Id);
            await _userBookService.Set(bookRequest, book.Id);

            return book;
        }

        private async Task<Book> SetBook(BookDTORequest bookRequest)
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

            return book;
        }
    }
}
