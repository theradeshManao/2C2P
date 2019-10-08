using assignment2C2P.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace assignment2C2P.Infrastructure.EF.Mapping
{
    public static class CustomerMapping
    {
        public static ModelBuilder CustomerMap(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();
            entity.ToTable("Customers");
            entity.Property(c => c.CustomerId).ValueGeneratedOnAdd().HasMaxLength(10);
            entity.Property(c => c.Name).HasMaxLength(30);
            entity.Property(c => c.Email).HasMaxLength(25);
            entity.Property(c => c.MobileNumber).HasMaxLength(10);
            entity.HasMany(t => t.Transactions).WithOne(t => t.Customer).HasForeignKey(t => t.CustomerId);
            return modelBuilder;
        }
    }
}
