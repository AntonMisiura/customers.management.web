using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace customers.management.impl.EF.Repo
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomersContext context) : base(context)
        {

        }

        public Customer GetCustomerContactsById(int id)
        {
            var customer = Context.Set<Customer>().Include(c => c.Contacts).ToList().FirstOrDefault(p => p.Id == id);
            return customer;
        }
    }
}
