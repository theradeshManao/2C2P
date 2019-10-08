using assignment2C2P.Models.Customers;
using System.Threading.Tasks;

namespace assignment2C2P.Infrastructure.EF.Repositories
{
    public interface IRepository
    {
        Task<Customer> GetByCustomerId(int customerId);
        Task<Customer> GetByEmail(string email);
        Task<Customer> GetByCustomerIdAndEmail(int customerId, string email);
    }
}
