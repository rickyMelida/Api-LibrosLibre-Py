using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IUserBookService
    {
        Task<UserBook> GetUserBookByBookId(int bookId);
        Task<List<UserBook>> GetUserBookByUserId(int userId);
        Task Set(BookDTORequest bookRequest, int bookId);
    }
}