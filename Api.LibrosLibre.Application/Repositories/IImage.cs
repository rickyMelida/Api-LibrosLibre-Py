using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IImageRepository
    {
        Task<List<Image>> GetImages();
        Task<Image> GetImageById(int id);
        Task<Image> CreateImage(Image image);
        Task<Image> UpdateImage(Image image);
        Task<bool> DeleteImage(int id);
        Task<int> GetLastId();

    }

}