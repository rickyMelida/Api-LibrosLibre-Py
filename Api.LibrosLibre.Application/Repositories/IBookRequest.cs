using Api.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IRequestedBookRepository
    {
        Task<List<RequestedBook>> GetRequestedBooks();
        Task<RequestedBook> GetRequestedBookById(int id);
        Task<bool> CreateRequestedBook(RequestedBook RequestedBook);
        Task<bool> UpdateRequestedBook(RequestedBook RequestedBook);
        Task<bool> DeleteRequestedBook(int id);
    }
}
