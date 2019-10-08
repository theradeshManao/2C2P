using assignment2C2P.Enums.TransactionStatuses;
using assignment2C2P.Models.Customers;
using System;

namespace assignment2C2P.Models.Transactions
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public static TransactionDto TransactionToDTO(Transaction t)
        {
            return new TransactionDto()
            {
                Id = t.TransactionId,
                Currency = t.CurrencyCode,
                Amount = t.Amount.ToString(),
                Status = t.TransactionStatus.ToString(),
                Date = t.DateTime.ToString("dd/MM/yyyy HH:MM")
        };
        }
    }
}
