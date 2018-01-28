using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.dto
{
    public class CustomerDetails
    {
        public Customer Customer { get; set; }

        public List<User> Users { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Department> Departments { get; set; }
    }
}
