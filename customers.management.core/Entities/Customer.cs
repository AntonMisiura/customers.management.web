using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class Customer : IEntity
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Comments { get; set; }

        public Type Type { get; set; }

        public List<User> Users { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
