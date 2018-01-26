using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using customers.management.core.Entities;

namespace customers.management.impl.EF
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SchoolNumber> SchoolNumbers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasOne(a => a.Manager)
                .WithOne(b => b.Department)
                .HasForeignKey<Department>(b => b.UserId);
        }
    }
}
