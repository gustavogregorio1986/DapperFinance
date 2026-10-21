using System.Transactions;

namespace DapperFinance.Repositoies
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task AddAsync(Transaction t);
        Task UpdateAsync(Transaction t);
        Task DeleteAsync(int id);

    }
}
