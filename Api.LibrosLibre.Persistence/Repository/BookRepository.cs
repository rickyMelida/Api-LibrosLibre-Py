using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Api.LibrosLibre.Application;
using Api.LibrosLibre.Application.Exceptions;

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
			try
			{
				await _context.Books.AddAsync(book);
				await _context.SaveChangesAsync();

				return book;
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error creating book: {ex.Message}");
			}
		}

		public async Task<Book> GetBookById(int id)
		{
			try
			{
				return await _context.Books.Where(x => x.Id == id).FirstAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error retrieving book with ID {id}: {ex.Message}");
			}
		}

		public async Task<List<Book>> GetBooks()
		{
			try
			{
				return await _context.Books.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error retrieving books: {ex.Message}");
			}
		}


		public async Task<Book> UpdateBook(Book book)
		{
			try
			{
				_context.Books.Update(book);
				await _context.SaveChangesAsync();
				return book;
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error updating book: {ex.Message}");
			}
		}

		public async Task<bool> DeleteBook(int id)
		{
			try
			{
				_context.Books.Remove(_context.Books.Find(id));
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error deleting book: {ex.Message}");
			}
		}

		public async Task<int> GetLastId()
		{
			try
			{
				return await _context.Books.AnyAsync() ? await _context.Books.MaxAsync(e => e.Id) : 0;
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error retrieving last book ID: {ex.Message}");
			}
		}

		public async Task<List<Book>> GetRecentBooks(int amount)
		{
			try
			{
				return await _context.Books
					.OrderByDescending(b => b.UploadDate)
					.Take(amount)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error retrieving recent books: {ex.Message}");
			}
		}

		public async Task<List<Book>> GetFeatureBooks(int amount)
		{
			try
			{
				return await _context.Books
					.OrderBy(b => b.Price)
					.Take(amount)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error retrieving feature books: {ex.Message}");
			}
		}

		public async Task<List<Book>> GetOtherBooks(int amount)
		{
			try
			{

				return await _context.Books
					.OrderBy(b => b.UploadDate)
					.Take(amount)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error retrieving other books: {ex.Message}");
			}
		}

		public async Task<List<Book>> SearchBook(string keyword)
		{
			try
			{
				return await _context.Books
					.Where(b => b.Author.Contains(keyword) ||
								b.Title.Contains(keyword) ||
								b.LitleDescription.Contains(keyword))
					.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new RepositoryException($"Error searching books: {ex.Message}");
			}
		}
	}

}