using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    }
}
