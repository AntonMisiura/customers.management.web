using System.Collections.Generic;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void SaveDepartments(List<Department> departments)
        {
            foreach (var dep in departments)
            {
                if (dep.Id == null)
                {
                    _departmentRepository.Add(dep);
                }
                else
                {
                    _departmentRepository.Edit(dep);
                }
            }

            _departmentRepository.Save();
        }

        public void DeleteDepartments(List<Department> departments)
        {
            foreach (var dep in departments)
            {
                if (dep.Id != null) _departmentRepository.Delete((int) dep.Id);
            }

            _departmentRepository.Save();
        }
    }
}
