using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class TypeTransactionRepository: ITypeTransactionRepository
    {
        private readonly AppDbContext _context;

        public TypeTransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TypeTransaction> CreateTypeTransaccion(TypeTransaction typeTransaccion)
        {
            _context.TypeTransactions.Add(typeTransaccion);
            _context.SaveChanges();

            return typeTransaccion;
        }

        public Task<bool> DeleteTypeTransaccion(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TypeTransaction> GetTypeTransaccionById(int id)
        {
            return await _context.TypeTransactions.FirstAsync(x => x.Id == id);
        }

        public Task<List<TypeTransaction>> GetTypeTransaccions()
        {
            throw new NotImplementedException();
        }

        public Task<TypeTransaction> UpdateTypeTransaccion(TypeTransaction typeTransaccion)
        {
            throw new NotImplementedException();
        }
    }
}