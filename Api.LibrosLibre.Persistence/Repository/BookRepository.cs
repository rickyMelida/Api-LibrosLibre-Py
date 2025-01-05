using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Api.LibrosLibre.Application;

namespace Api.LibrosLibre.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(AppDbContext context, IUnitOfWork unitOfWork) =>
            (_context, _unitOfWork) = (context, unitOfWork);

        public async Task<Book> CreateBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _unitOfWork.Save();
            return book;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FirstAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }


        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _unitOfWork.Save();
            return book;
        }

        public Task<bool> DeleteBook(int id)
        {
            _ = _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public async Task<int> GetLastId()
        {
            return await _context.Books.MaxAsync(e => e.Id);
        }
    }

}