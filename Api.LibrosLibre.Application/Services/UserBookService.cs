
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository _userBookRepository;
        public UserBookService(IUserBookRepository userBookRepository) =>
            _userBookRepository = userBookRepository;

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
            UserBook userBook = new UserBook()
            {
                User = bookRequest.User,
                Book = bookId
            };

            await _userBookRepository.CreateUserBook(userBook);
        }
    }
}