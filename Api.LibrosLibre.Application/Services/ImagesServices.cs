using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class ImagesServices : IBookImagesService
    {
        private readonly IImageRepository _imageRepository;
        public ImagesServices(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<List<Image>> GetRelevantBookImages()
        {
            var images = await _imageRepository.GetImages();

            return images.ToList();
        }
    }

}