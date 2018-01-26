using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        /// <summary>
        /// get departments of customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Department> GetByCustomerId(int id);
    }
}
