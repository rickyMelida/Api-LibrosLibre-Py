using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IImagesService
    {
        Task<List<Image>> GetRelevantBookImages();
        Task<List<Image>> GetImagesByBookId(int bookId);
        Task<int> SetImages(BookDTORequest bookRequest, int bookId);
    }

}