using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository,
            IUserService userService)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department> GetDepartmentsByCustomerId(int id)
        {
            var departments = _departmentRepository.GetByCustomerId(id);

            return departments;
        }

        public void AddDepartment(Department department)
        {
            _departmentRepository.Add(department);
        }

        public void EditDepartment(Department department)
        {
            _departmentRepository.Edit(department);
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
        }
    }
}
