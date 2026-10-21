using System.ComponentModel.DataAnnotations;

namespace DapperFinance.DTOs
{
    public class CategoryTotalDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public string CategoryName { get; set; } = "";
    }
}
