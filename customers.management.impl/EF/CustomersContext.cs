using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Entities;

namespace customers.management.impl.EF
{
    public class CustomersContext : DbContext
    {
        private IConfigurationRoot _config;

        public CustomersContext(IConfigurationRoot config, DbContextOptions options) 
            : base(options)
        {
            _config = config;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
