using assignment2C2P.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Infrastructure.EF.Seeding
{
    public class CustomerSeeding
    {
        public static void Seed(AssignmentDB context)
        {
            var customer1 = new Customer()
            {
                Name = "Firstname Lastname",
                Email = "user@domain.com",
                MobileNumber = "0123456789",
            };

            var customer2 = new Customer()
            {
                Name = "Firstname2 Lastname",
                Email = "user2@domain.com",
                MobileNumber = "0123456789",
            };

            context.Add(customer1);
            context.Add(customer2);
            context.SaveChanges();

        }
    }
}
