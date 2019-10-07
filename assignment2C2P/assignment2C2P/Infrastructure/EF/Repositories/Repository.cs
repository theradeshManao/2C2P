
using System.Linq;
using System.Threading.Tasks;
using assignment2C2P.Infrastructure.EF.Repositories;
using assignment2C2P.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace assignment2C2P.Infrastructure.EF.Repositories
{
    public class Repository : IRepository
    {
        public AssignmentDB context { get; set; }

        public Repository(AssignmentDB context)
        {
            this.context = context;
        }

        public async Task<Customer> GetByCustomerId(int customerId)
        {
            var customer = await context.Customers
                .Include(t => t.Transactions)
                .SingleOrDefaultAsync(c => c.CustomerId == customerId);
            customer?.Transactions?.OrderByDescending(x => x.CustomerId).Take(5).ToList();
            return customer;
        }

        public async Task<Customer> GetByEmail(string email)
        {
            var customer = await context.Customers
                .Include(t => t.Transactions)
                .SingleOrDefaultAsync(c => c.Email == email);
            customer?.Transactions?.OrderByDescending(x => x.CustomerId).Take(5).ToList();
            return customer;
        }
    }
}
