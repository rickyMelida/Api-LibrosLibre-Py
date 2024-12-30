using Api.LibrosLibre.Application;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class BookStateRepository: IBookStateRepository
    {
        private readonly AppDbContext _context;

        public BookStateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.BookState>> GetBookStates()
        {
            return await _context.BookStates.ToListAsync();
        }

        public async Task<Domain.BookState> GetBookStateById(int id)
        {
            return await _context.BookStates.FirstAsync(x => x.Id == id);
        }

        public async Task<bool> CreateBookState(Domain.BookState bookState)
        {
            await _context.BookStates.AddAsync(bookState);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookState(Domain.BookState bookState)
        {
            _context.BookStates.Update(bookState);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookState(int id)
        {
            var bookState = await _context.BookStates.FirstOrDefaultAsync(x => x.Id == id);
            _context.BookStates.Remove(bookState);
            await _context.SaveChangesAsync();
            return true;
        }
    }



}