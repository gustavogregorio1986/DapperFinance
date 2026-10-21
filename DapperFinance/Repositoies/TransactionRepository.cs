using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace DapperFinance.Repositoies
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private DbConnection GetConnection() => new SqlConnection(_connectionString);

        public Task AddAsync(Transaction t)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
           using var connection = GetConnection();
            var sql = @"SELECT  * FROM Categories";
            return connection.QueryAsync<Transaction>(sql);
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            using var conn = GetConnection();
            var sql = @"SELECT  * FROM Categories where Id = @Id";
            return await conn.QueryFirstOrDefaultAsync<Transaction>(sql, new { Id = id });
        }

        public Task UpdateAsync(Transaction t)
        {
            throw new NotImplementedException();
        }
    }
}
