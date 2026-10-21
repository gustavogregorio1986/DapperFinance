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
           using var conn = GetConnection();
            var sql = @"INSERT INTO Transactions (Type, CategforyId, Description, Amount, Date) VALUES (@Type, @CategoryId, @Description, @Amount, @Date)";
            return conn.ExecuteAsync(sql, t);
        }

        public Task DeleteAsync(int id)
        {
            using var conn = GetConnection();
            var sql = @"DELETE FROM Categories WHERE Id = @Id";
            return conn.ExecuteAsync(sql, new { Id = id });
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
           using var conn = GetConnection();
            var sql = @"UPDATE Transactions SET Type = @Type, CategoryId = @CategoryId, Description = @Description, Amount = @Amount, Date = @Date WHERE Id = @Id";
            return conn.ExecuteAsync(sql, t);
        }
    }
}
