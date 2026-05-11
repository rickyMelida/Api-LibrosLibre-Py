using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class ImagesServices : IImagesService
    {
        private readonly IImageRepository _imageRepository;

        public ImagesServices(IImageRepository imageRepository) =>
            _imageRepository = imageRepository;

        public async Task<List<Image>> GetImagesByBookId(int bookId)
        {
            return await _imageRepository.GetImageByBookId(bookId);
        }

        public async Task<List<Image>> GetRelevantBookImages()
        {
            var images = await _imageRepository.GetImages();

            return images.ToList();
        }

        public async Task SetImages(BookDTORequest bookRequest, int bookId)
        {
            foreach (var picture in bookRequest.Images)
            {
                using var ms = new MemoryStream();
                await picture.CopyToAsync(ms);
                var imageBytes = ms.ToArray();

                Image image = new Image()
                {
                    BookId = bookId,
                    Description = $"{bookRequest.Title} - {bookRequest.Author}",
                    Picture = imageBytes
                };

                await _imageRepository.CreateImage(image);
            }
        }
    }

}