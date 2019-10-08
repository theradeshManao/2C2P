using System.Threading.Tasks;
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
                .Include(c => c.Transactions)
                .SingleOrDefaultAsync(c => c.CustomerId == customerId);
            return customer;
        }

        public async Task<Customer> GetByEmail(string email)
        {
            var customer = await context.Customers
                .Include(c => c.Transactions)
                .SingleOrDefaultAsync(c => c.Email == email);
            return customer;
        }

        public async Task<Customer> GetByCustomerIdAndEmail(int customerId, string email)
        {
            var customer = await context.Customers
                .Include(c => c.Transactions)
                .SingleOrDefaultAsync(c => c.CustomerId == customerId && c.Email == email);
            return customer;
        }
    }
}
