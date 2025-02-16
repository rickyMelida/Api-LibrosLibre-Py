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

        public async Task<Image> CreateImage(Image image)
        {
            await _context.Images.AddAsync(image);
            await _unitOfWork.Save();
            return image;
        }

        public Task<bool> DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> GetImageByBookId(int id)
        {
            return await _context.Images.Where(e => e.BookId == id).ToListAsync();
        }

        public Task<Image> GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<int> GetLastId()
        {
            return await _context.Images.AnyAsync() ? await _context.Images.MaxAsync(x => x.Id) : 0;
        }

        public Task<Image> UpdateImage(Image image)
        {
            throw new NotImplementedException();
        }
    }

}