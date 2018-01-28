using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class SchoolNumber : IEntity
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        
        public int Number { get; set; }
    }
}
