using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class BookService : IBookService
    {
        public Task<List<Book>> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetFeaturedBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetOthersBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetRecentsBooks()
        {
            throw new NotImplementedException();
        }
    }
}
