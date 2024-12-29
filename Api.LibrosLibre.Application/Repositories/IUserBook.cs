using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IUserBookRepository
    {
        Task<List<UserBook>> GetUserBooks();
        Task<UserBook> GetUserBookById(int id);
        Task<bool> CreateUserBook(UserBook userBook);
        Task<bool> UpdateUserBook(UserBook userBook);
        Task<bool> DeleteUserBook(int id);
    }
}
