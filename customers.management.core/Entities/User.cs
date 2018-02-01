using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public int DepartmentId{ get; set; }

        public Department Department { get; set; }
    }
}
