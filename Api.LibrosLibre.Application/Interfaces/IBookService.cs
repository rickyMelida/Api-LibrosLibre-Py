using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<List<Book>> GetRecentsBooks();
        Task<List<Book>> GetFeaturedBooks();
        Task<List<Book>> GetOthersBooks();
        Task<Book> GetBookById(int id);
        Task<Book> GetBookByUserId(int id);
        Task<bool> CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);

    }
}
