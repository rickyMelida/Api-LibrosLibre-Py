using Api.LibrosLibre.Application.DTOs;

namespace Api.LibrosLibre.Application
{
    public interface IImagesService
    {
        Task<List<ImageDTO>> GetRelevantBookImages();
        Task<List<ImageDTO>> GetImagesByBookId(int bookId);
        Task SetImages(BookDTORequest bookRequest, int bookId);
    }

}