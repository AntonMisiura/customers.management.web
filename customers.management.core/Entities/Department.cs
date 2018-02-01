using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class Department : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public Manager Manager { get; set; }

        //public List<User> Users { get; set; }
    }
}
