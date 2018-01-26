using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace customers.management.impl.EF.Repo
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CustomersContext context) : base(context)
        {
        }

        public List<Department> GetByCustomerId(int id)
        {
            var departments = Context.Set<Department>().Include(e => e.Manager).ToList();
            var selected = departments.Where(e => e.CustomerId == id).ToList();
            return selected;
        }
    }
}
