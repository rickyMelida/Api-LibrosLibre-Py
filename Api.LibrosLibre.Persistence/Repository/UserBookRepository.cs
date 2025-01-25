using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserBookRepository(AppDbContext context, IUnitOfWork unitOfWork) =>
            (_context, _unitOfWork) = (context, unitOfWork);

        public async Task<bool> CreateUserBook(UserBook userBook)
        {
            await _context.UserBooks.AddAsync(userBook);
            await _unitOfWork.Save();
            return true;
        }

        public Task<bool> DeleteUserBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastId()
        {
            return await _context.UserBooks.AnyAsync() ? await _context.UserBooks.MaxAsync(x => x.Id) : 0;
        }

        public Task<UserBook> GetUserBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBook>> GetUserBooks()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserBook(UserBook userBook)
        {
            throw new NotImplementedException();
        }
    }
}
