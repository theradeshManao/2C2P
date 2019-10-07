
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
                .SingleOrDefaultAsync(x => x.CustomerId == customerId);
            return customer;
        }
    }
}
