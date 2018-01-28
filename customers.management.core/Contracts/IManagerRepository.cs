using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IManagerRepository
    {
        Manager GetByDepartmentId(int id);
    }
}
