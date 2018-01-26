using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class CustomerContactRepository : ICustomerContactRepository
    {
        private CustomersContext _context;

        public CustomerContactRepository(CustomersContext context)
        {
            _context = context;
        }

        public List<CustomerContact> GetByCustomerId(int id)
        {
            var selected = _context.Set<CustomerContact>().Where(e => e.CustomerId == id).ToList();
            return selected;
        }

        public List<CustomerContact> GetByContactId(int id)
        {
            var selected = _context.Set<CustomerContact>().Where(e => e.ContactId == id).ToList();
            return selected;
        }
    }
}
