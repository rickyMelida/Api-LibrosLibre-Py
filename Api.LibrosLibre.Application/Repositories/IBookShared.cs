using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookSharedRepository
    {
        Task<List<BookShared>> GetBookShareds();
        Task<BookShared> GetBookSharedById(int id);
        Task<bool> CreateBookShared(BookShared bookShared);
        Task<bool> UpdateBookShared(BookShared bookShared);
        Task<bool> DeleteBookShared(int id);
    }
}
