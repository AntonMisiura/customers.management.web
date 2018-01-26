using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface ICustomerContactRepository
    {
        List<CustomerContact> GetByCustomerId(int id);

        List<CustomerContact> GetByContactId(int id);
    }
}
