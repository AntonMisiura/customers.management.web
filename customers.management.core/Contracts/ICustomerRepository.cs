using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerContactsById(int id);

    }
}
