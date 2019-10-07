using assignment2C2P.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Infrastructure.EF.Repositories
{
    public interface IRepository
    {
        Task<Customer> GetByCustomerId(int customerId);
        Task<Customer> GetByEmail(string email);
    }
}
