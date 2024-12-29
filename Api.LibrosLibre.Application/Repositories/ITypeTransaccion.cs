using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface ITypeTransaccionRepository
    {
        Task<List<TypeTransaction>> GetTypeTransaccions();
        Task<TypeTransaction> GetTypeTransaccionById(int id);
        Task<bool> CreateTypeTransaccion(TypeTransaction typeTransaccion);
        Task<bool> UpdateTypeTransaccion(TypeTransaction typeTransaccion);
        Task<bool> DeleteTypeTransaccion(int id);
    }
}
