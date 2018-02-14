using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Comments { get; set; }
        
        public int TypeId { get; set; }

        public Type Type { get; set; }

        public SchoolNumber NumbersOfSchool { get; set; }

        public List<User> Users { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
