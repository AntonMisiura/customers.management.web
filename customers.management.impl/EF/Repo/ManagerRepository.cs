using System.Linq;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class ManagerRepository : IManagerRepository
    {
        protected CustomersContext Context { get; private set; }

        public ManagerRepository(CustomersContext context)
        {
            Context = context;
        }

        public Manager GetByDepartmentId(int id)
        {
            var manager = Context.Set<Manager>().FirstOrDefault(m => m.DepartmentId == id);

            return manager;
        }
    }
}
