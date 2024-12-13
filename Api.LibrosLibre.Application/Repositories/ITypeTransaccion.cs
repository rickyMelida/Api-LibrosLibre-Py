namespace Api.LibrosLibre.Application
{
    public interface ITypeTransaccionRepository
    {
        Task<List<TypeTransaccion>> GetTypeTransaccions();
        Task<TypeTransaccion> GetTypeTransaccionById(int id);
        Task<bool> CreateTypeTransaccion(TypeTransaccion typeTransaccion);
        Task<bool> UpdateTypeTransaccion(TypeTransaccion typeTransaccion);
        Task<bool> DeleteTypeTransaccion(int id);
    }
}
