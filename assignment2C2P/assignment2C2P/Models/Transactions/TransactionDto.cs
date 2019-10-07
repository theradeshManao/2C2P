using assignment2C2P.Enums.TransactionStatuses;
using assignment2C2P.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Models.Transactions
{
    public class TransactionDto
    {
        public long Id { get; set; } // Numeric dont have max limit
        public string Date { get; set; } // DD/MM/YY HH:MM e.g. 31/02/2018 21:34
        public string Amount { get; set; } // 2 decimal points
        public string Currency { get; set; } // have only 3 characters
        public string Status { get; set; } // have 3 chars
    }
}
