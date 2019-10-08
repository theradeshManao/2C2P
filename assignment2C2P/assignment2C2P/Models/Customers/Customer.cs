using assignment2C2P.Models.Transactions;
using System.Collections.Generic;

namespace assignment2C2P.Models.Customers
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CustomerDto CustomerToDto()
        {
            var transactions = new List<TransactionDto>();
            foreach (var t in this.Transactions)
            {
                if (transactions.Count < 5)
                {
                    var dto = Transaction.TransactionToDTO(t);
                    transactions.Add(dto);
                }
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
