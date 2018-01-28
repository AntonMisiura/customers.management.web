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
            throw new NotImplementedException();
        }
    }
}
