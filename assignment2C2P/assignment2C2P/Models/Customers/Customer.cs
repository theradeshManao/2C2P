using assignment2C2P.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Models.Customers
{
    public class Customer
    {
        public long CustomerID { get; set; } // Numberic max 10 chars
        public string Name { get; set; } // Character max 30 chars
        public string Email { get; set; } //Character max 25 digits
        public string MobileNumber { get; set; } // Numeric only 10 digits
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // max 5 records
    }
}
