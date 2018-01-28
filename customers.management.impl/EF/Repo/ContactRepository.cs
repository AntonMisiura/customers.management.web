using System.Collections.Generic;
using System.Linq;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(CustomersContext context) : base(context)
        {
            
        }

        public List<Contact> GetByCustomerId(int id)
        {
            return Context.Set<Contact>().Where(e => e.CustomerId == id).ToList();
        }
    }
}
