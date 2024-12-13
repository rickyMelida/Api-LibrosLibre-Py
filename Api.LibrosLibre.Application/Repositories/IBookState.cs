namespace Api.LibrosLibre.Application
{
    public interface IBookStateRepository
    {
        Task<List<BookState>> GetBookStates();
        Task<BookState> GetBookStateById(int id);
        Task<bool> CreateBookState(BookState bookState);
        Task<bool> UpdateBookState(BookState bookState);
        Task<bool> DeleteBookState(int id);
    }
}
