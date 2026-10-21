using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace DapperFinance.Repositoies
{
    public interface ICategoryRrepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetByIdAsync(int categoryId);
    }
}
