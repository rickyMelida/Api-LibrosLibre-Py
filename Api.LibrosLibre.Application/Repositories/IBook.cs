using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<int> GetLastId();
        Task<List<Book>> GetRecentBooks(int amount);
        Task<List<Book>> GetFeatureBooks(int amount);
        Task<List<Book>> GetOtherBooks(int amount);
        Task<List<Book>> SearchBook(string keyword);
    }
    
}