using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class Type : IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
