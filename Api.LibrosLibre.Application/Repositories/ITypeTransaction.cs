using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface ITypeTransactionRepository
    {
        Task<List<TypeTransaction>> GetTypeTransaccions();
        Task<TypeTransaction> GetTypeTransaccionById(int id);
        Task<TypeTransaction> CreateTypeTransaccion(TypeTransaction typeTransaccion);
        Task<TypeTransaction> UpdateTypeTransaccion(TypeTransaction typeTransaccion);
        Task<bool> DeleteTypeTransaccion(int id);
    }
}
