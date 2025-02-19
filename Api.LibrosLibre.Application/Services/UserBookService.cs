
using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository _userBookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserBookService(IUserBookRepository userBookRepository, IUnitOfWork unitOfWork) =>
            (_userBookRepository, _unitOfWork) = (userBookRepository, unitOfWork);

        public async Task<UserBook> GetUserBookByBookId(int bookId)
        {
            return await _userBookRepository.GetUserBookById(bookId);
        }

        public async Task<List<UserBook>> GetUserBookByUserId(int userId)
        {
            return await _userBookRepository.GetUserBookByUserId(userId);
        }

        public async Task Set(BookDTORequest bookRequest, int bookId)
        {
            int userBookId = await _userBookRepository.GetLastId() + 1;
            UserBook userBook = new UserBook()
            {
                Id = userBookId,
                User = bookRequest.User,
                Book = bookId
            };

            await _userBookRepository.CreateUserBook(userBook);
            await _unitOfWork.Save();
        }
    }
}