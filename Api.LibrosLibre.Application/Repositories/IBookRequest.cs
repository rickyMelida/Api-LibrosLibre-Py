using Api.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookRequestRepository
    {
        Task<List<BookRequest>> GetBookRequests();
        Task<BookRequest> GetBookRequestById(int id);
        Task<bool> CreateBookRequest(BookRequest bookRequest);
        Task<bool> UpdateBookRequest(BookRequest bookRequest);
        Task<bool> DeleteBookRequest(int id);
    }
}
