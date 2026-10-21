using System.ComponentModel.DataAnnotations;

namespace DapperFinance.DTOs
{
    public class TransactionCreateDto
    {
        [Required]
        public char Type { get; set; }

        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public DateTime Data { get; set; }

        public string? Description { get; set; }
    }
}
