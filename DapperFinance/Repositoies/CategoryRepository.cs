using Dapper;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperFinance.Repositoies
{
    public class CategoryRepository : ICategoryRrepository
    {
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }  
            

        private IDbConnection CreateConnectionm() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            using var conn = CreateConnectionm();
            var sql = "SELECT * FROM Categories";
            return await conn.QueryAsync<Category>(sql);
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            using var conn = CreateConnectionm();
            var sql = "SELECT * FROM Categories where Id = @Id";
            return await conn.QueryFirstOrDefaultAsync<Category>(sql, new { id = id });
        }
    }
}
