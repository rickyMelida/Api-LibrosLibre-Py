using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;
using AutoMapper;

namespace Api.LibrosLibre.Application
{
    public class ImagesServices : IImagesService
    {
        private readonly IImageRepository _imageRepository;
		private readonly IMapper _mapper;

        public ImagesServices(IImageRepository imageRepository, IMapper mapper) =>
            (_imageRepository, _mapper) = (imageRepository, mapper);

        public async Task<List<ImageDTO>> GetImagesByBookId(int bookId)
        {
			var images = await _imageRepository.GetImageByBookId(bookId);
            return _mapper.Map<List<ImageDTO>>(images);
        }

        public async Task<List<ImageDTO>> GetRelevantBookImages()
        {
            var images = await _imageRepository.GetImages();
			var firstImages = images
			.GroupBy(e => e.BookId)
			.Select(group => group.OrderBy(img => img.Id).First())
			.ToList();

            return _mapper.Map<List<ImageDTO>>(firstImages);
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