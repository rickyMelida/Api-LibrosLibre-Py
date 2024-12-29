using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task<bool> CreateTransaction(Transaction transaction);
        Task<bool> UpdateTransaction(Transaction transaction);
        Task<bool> DeleteTransaction(int id);
    }
}
