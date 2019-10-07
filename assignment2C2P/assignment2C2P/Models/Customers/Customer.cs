using assignment2C2P.Models.Transactions;
using System.Collections.Generic;

namespace assignment2C2P.Models.Customers
{
    public class Customer
    {
        public long CustomerId { get; set; } // Numberic max 10 chars
        public string Name { get; set; } // Character max 30 chars
        public string Email { get; set; } //Character max 25 digits
        public string MobileNumber { get; set; } // Numeric only 10 digits
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // max 5 records

        public CustomerDto CustomerToDto()
        {
            var transactions = new List<TransactionDto>();
            foreach (var t in this.Transactions)
            {
                var dto = Transaction.TransactionToDTO(t);
                transactions.Add(dto);
            }

            return new CustomerDto()
            {
                CustomerID = this.CustomerId,
                Name = this.Name,
                Mobile = this.MobileNumber,
                Email = this.Email,
                Transactions = transactions
            };
        }
    }
}
