using Api.LibrosLibre.Application;

namespace Api.LibrosLibre.Persistence 
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}