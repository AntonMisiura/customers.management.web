using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http.Headers;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(CustomersContext context) : base(context)
        {
            
        }
    }
}
