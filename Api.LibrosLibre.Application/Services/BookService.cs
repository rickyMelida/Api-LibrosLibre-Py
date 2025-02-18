using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImagesService _bookImagesService;
        private readonly IUserBookService _userBookService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository,
                           IImagesService bookImagesService,
                           IUserBookService userBookService,
                           IUserService userService,
                           IUnitOfWork unitOfWork) =>
            (_bookRepository, _bookImagesService, _userBookService, _userService, _unitOfWork) =
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

        public async Task<List<BookDTOResponse>> GetFeaturedBooks(int amount)
        {
            var featuresBooks = await _bookRepository.GetFeatureBooks(amount);
            List<BookDTOResponse> booksResults = new List<BookDTOResponse>();

            foreach (var book in featuresBooks)
            {
                var image = await _bookImagesService.GetImagesByBookId(book.Id);
                var userBook = await _userBookService.GetImagesByBookId(book.Id);
                var user = await _userService.GetUserById(userBook.User);

                booksResults.Add(new BookDTOResponse
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
                });
            }

            return booksResults;

        }

        public async Task<List<BookDTOResponse>> GetOthersBooks(int amount)
        {
            var featuresBooks = await _bookRepository.GetOtherBooks(amount);
            List<BookDTOResponse> booksResults = new List<BookDTOResponse>();

            foreach (var book in featuresBooks)
            {
                var image = await _bookImagesService.GetImagesByBookId(book.Id);
                var userBook = await _userBookService.GetImagesByBookId(book.Id);
                var user = await _userService.GetUserById(userBook.User);

                booksResults.Add(new BookDTOResponse
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
                });
            }

            return booksResults;
        }

        public async Task<List<BookDTOResponse>> GetRecentsBooks(int amount)
        {
            var featuresBooks = await _bookRepository.GetRecentBooks(amount);
            List<BookDTOResponse> booksResults = new List<BookDTOResponse>();

            foreach (var book in featuresBooks)
            {
                var image = await _bookImagesService.GetImagesByBookId(book.Id);
                var userBook = await _userBookService.GetImagesByBookId(book.Id);
                var user = await _userService.GetUserById(userBook.User);

                booksResults.Add(new BookDTOResponse
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
                });
            }

            return booksResults;
        }

        public async Task<List<BookDTOResponse>> SearchBook(string keyword)
        {
            var booksResult = await _bookRepository.SearchBook(keyword);
            List<BookDTOResponse> booksResultFormat = new List<BookDTOResponse>();

            foreach (var book in booksResult)
            {
                var image = await _bookImagesService.GetImagesByBookId(book.Id);
                var userBook = await _userBookService.GetImagesByBookId(book.Id);
                var user = await _userService.GetUserById(userBook.User);

                booksResultFormat.Add(new BookDTOResponse
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
                });
            }

            return booksResultFormat;
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
