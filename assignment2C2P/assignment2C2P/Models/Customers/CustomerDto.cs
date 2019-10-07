using assignment2C2P.Models.Transactions;
using System.Collections.Generic;

namespace assignment2C2P.Models.Customers
{
    public class CustomerDto
    {
        public long CustomerID { get; set; } // Numberic max 10 chars
        public string Name { get; set; } // Character max 30 chars
        public string Email { get; set; } //Character max 25 digits
        public string Mobile { get; set; } // Numeric only 10 digits
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>(); // max 5 records
    }
}
