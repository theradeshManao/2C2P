namespace assignment2C2P.Models.Transactions
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
