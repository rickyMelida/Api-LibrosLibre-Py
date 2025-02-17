using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class ImagesServices : IImagesService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImagesServices(IImageRepository imageRepository, IUnitOfWork unitOfWork) =>
            (_imageRepository, _unitOfWork) = (imageRepository, unitOfWork);

        public async Task<List<Image>> GetImagesByBookId(int bookId)
        {
            return await _imageRepository.GetImageByBookId(bookId);
        }

        public async Task<List<Image>> GetRelevantBookImages()
        {
            var images = await _imageRepository.GetImages();

            return images.ToList();
        }

        public async Task<int> SetImages(BookDTORequest bookRequest, int bookId)
        {
            int imageId = await _imageRepository.GetLastId();

            foreach (var picture in bookRequest.Images)
            {
                using var ms = new MemoryStream();
                await picture.CopyToAsync(ms);
                var imageBytes = ms.ToArray();
                imageId = imageId + 1;

                Image image = new Image()
                {
                    Id = imageId,
                    BookId = bookId,
                    Description = $"{bookRequest.Title} - {bookRequest.Author}",
                    Picture = imageBytes
                };

                await _imageRepository.CreateImage(image);
                await _unitOfWork.Save();
            }

            return imageId;
        }
    }

}