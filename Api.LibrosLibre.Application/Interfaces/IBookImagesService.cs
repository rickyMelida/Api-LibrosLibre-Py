using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IBookImagesService
    {
        Task<List<Image>> GetRelevantBookImages();
    }

}