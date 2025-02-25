using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookService
    {
        Task<BookDTOResponse> GetBook(int id);
        Task<List<BookDTOResponse>> GetRecentsBooks(int amount);
        Task<List<BookDTOResponse>> GetFeaturedBooks(int amount);
        Task<List<BookDTOResponse>> GetOthersBooks(int amount);
        Task<Book> SetNewBook(BookDTORequest bookRequest);
        Task<List<BookDTOResponse>> SearchBook(string keyword);
        Task<List<BookDTOResponse>> GetBooksByUser(int userId);
        Task<List<BookDTOResponse>> GetFavoritesBooks(int userId);
        Task<int> SetFavoriteBook(int userId, int bookId);

    }
}
