using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUserBookRepository _userBookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IImageRepository imageRepository, IUserBookRepository userBookRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) =>
            (_bookRepository, _imageRepository, _userBookRepository, _userRepository, _unitOfWork) =
            (bookRepository, imageRepository, userBookRepository, userRepository, unitOfWork);

        public async Task<BookDTOResponse> GetBook(int id)
        {

            var book = await _bookRepository.GetBookById(id);
            var image = await _imageRepository.GetImageByBookId(book.Id);
            var userBook = await _userBookRepository.GetUserBookById(book.Id);
            var user = await _userRepository.GetUserById(userBook.User);

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
            int imageId = await _imageRepository.GetLastId() + 1;
            // TODO Separate this in his service 
            Image image = new Image();
            if(bookRequest.Image != null) {
                using var ms = new MemoryStream();
                await bookRequest.Image.CopyToAsync(ms);
                var imageBytes = ms.ToArray();

                image = new Image()
                {
                    Id = imageId,
                    BookId = book.Id,
                    Description = "Book Image",
                    Picture = imageBytes
                };
            }

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
