using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomersContext context) : base(context)
        {

        }
    }
}
