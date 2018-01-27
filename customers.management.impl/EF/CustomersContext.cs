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
        public DbSet<DepartmentUser> DepartmentUser { get; set; }
    }
}
