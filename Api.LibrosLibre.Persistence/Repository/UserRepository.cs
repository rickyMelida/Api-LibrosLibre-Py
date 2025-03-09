using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(AppDbContext context, IUnitOfWork unitOfWork) =>
            (_context, _unitOfWork) = (context, unitOfWork);

        public Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastId()
        {
            return await _context.Users.AnyAsync() ? await _context.Users.MaxAsync(x => x.Id) : 0;
        }

        public Task<User> GetUserById(int id)
        {
            return _context.Users.Where(e => e.Id == id).FirstAsync();
        }

        public async Task<User> GetUserByMail(string mail)
        {
            return await _context.Users.Where(e => e.Email == mail).FirstAsync();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserValid(User user)
        {
            var existingUser = await _context.Users.Where(e => e.Email == user.Email && e.Name == user.Name).FirstOrDefaultAsync();
            return existingUser != null;
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
