using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public User Manager { get; set; }
    }
}
