using assignment2C2P.Enums.TransactionStatuses;
using assignment2C2P.Models.Transactions;
using System;
using System.Linq;

namespace assignment2C2P.Infrastructure.EF.Seeding
{
    public class TransactionSeeding
    {
        public static void Seed(AssignmentDB context)
        {
            var customer1 = context.Customers.First();
            var customer2 = context.Customers.Last();

            var transaction1 = new Transaction()
            {
                CurrencyCode = "USD",
                Amount = 1,
                TransactionStatus = TransactionStatus.Success,
                DateTime = new DateTime(2016, 7, 15, 3, 15, 0),
                CustomerId = customer1.CustomerId
            };

            var transaction2 = new Transaction()
            {
                CurrencyCode = "THB",
                Amount = 1.11,
                TransactionStatus = TransactionStatus.Failed,
                DateTime = new DateTime(2016, 7, 15, 11, 15, 0),
                CustomerId = customer1.CustomerId
            };

            var transaction3 = new Transaction()
            {
                CurrencyCode = "AED",
                Amount = 1.11111111,
                TransactionStatus = TransactionStatus.Canceled,
                DateTime = new DateTime(2016, 7, 15, 11, 15, 0),
                CustomerId = customer1.CustomerId
            };

            var transaction4 = new Transaction()
            {
                CurrencyCode = "AFN",
                Amount = 112545.2545,
                TransactionStatus = TransactionStatus.Success,
                DateTime = new DateTime(2016, 7, 15, 3, 15, 0),
                CustomerId = customer1.CustomerId
            };

            var transaction5 = new Transaction()
            {
                CurrencyCode = "ALL",
                Amount = 10000000,
                TransactionStatus = TransactionStatus.Failed,
                DateTime = new DateTime(2016, 7, 15, 11, 15, 0),
                CustomerId = customer1.CustomerId
            };

            var transaction6 = new Transaction()
            {
                CurrencyCode = "BHD",
                Amount = 10000000,
                TransactionStatus = TransactionStatus.Canceled,
                DateTime = new DateTime(2016, 7, 15, 11, 15, 0),
                CustomerId = customer1.CustomerId
            };

            context.Add(transaction1);
            context.Add(transaction2);
            context.Add(transaction3);
            context.Add(transaction4);
            context.Add(transaction5);
            context.Add(transaction6);

            context.SaveChanges();
        }
    }
}
