using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IContactRepository : IRepository<Contact>
    {
        List<Contact> GetByCustomerId(int id);
    }
}
