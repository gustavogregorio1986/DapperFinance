namespace DapperFinance.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public char Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Data { get; set; }

        public int CategoryId { get; set; }

        public string? Description { get; set; }
    }
}
