using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookService
    {
        Task<List<Book>> GetBook(int id);
        Task<List<BookRequest>> GetRecentsBooks(int amount);
        Task<List<BookRequest>> GetFeaturedBooks(int amount);
        Task<List<BookRequest>> GetOthersBooks(int amount);
        Task<Book> SetBook(BookRequest bookRequest);

    }
}
