using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IDepartmentService
    {
        /// <summary>
        /// edit and delete departments
        /// </summary>
        /// <param name="departments"></param>
        void SaveDepartments(List<Department> departments);

        /// <summary>
        /// delete list of departments
        /// </summary>
        /// <param name="departments"></param>
        void DeleteDepartments(List<Department> departments);
    }
}
