using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ImageRepository(AppDbContext context, IUnitOfWork unitOfWork) =>
            (_context, _unitOfWork) = (context, unitOfWork);

        public Task<Image> CreateImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> GetImages()
        {
            return await _context.Images.ToListAsync<Image>();
        }

        public Task<Image> UpdateImage(Image image)
        {
            throw new NotImplementedException();
        }
    }

}