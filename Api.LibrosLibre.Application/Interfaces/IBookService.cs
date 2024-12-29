using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookService
    {
        Task<List<Book>> GetBook(int id);
        Task<List<Book>> GetRecentsBooks();
        Task<List<Book>> GetFeaturedBooks();
        Task<List<Book>> GetOthersBooks();

    }
}
