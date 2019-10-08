using assignment2C2P.Infrastructure.EF.Mapping;
using assignment2C2P.Models.Customers;
using assignment2C2P.Models.Transactions;
using Microsoft.EntityFrameworkCore;

namespace assignment2C2P.Infrastructure.EF
{
    public class AssignmentDB : DbContext
    {
        public AssignmentDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CustomerMap();
            modelBuilder.TransactionMap();
            base.OnModelCreating(modelBuilder);
        }
    }
}
