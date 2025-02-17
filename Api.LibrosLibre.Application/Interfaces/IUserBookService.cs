using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IUserBookService
    {
        Task<UserBook> GetImagesByBookId(int bookId);
        Task Set(BookDTORequest bookRequest, int bookId);
    }
}