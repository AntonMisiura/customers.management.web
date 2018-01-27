using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUserRepository _userRepository;
        private IDepartmentRepository _departmentRepository;
        private IDepartmentUserRepository _departmentUserRepository;

        public DepartmentService(IDepartmentRepository departmentRepository,
            IUserRepository userRepository,
            IDepartmentUserRepository departmentUserRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _departmentUserRepository = departmentUserRepository;
        }

        public List<Department> GetDepartmentsByCustomerId(int id)
        {
            var users = _userRepository.GetByCustomerId(id);
            var depUsers = _departmentUserRepository.GetAll();
            var departments = _departmentRepository.GetByCustomerId(id);

            foreach (var dep in departments)
            {
                foreach (var user in users)
                {
                    if (dep.ManagerId == user.Id)
                    {
                        dep.Manager = new User()
                        {
                            Name = user.Name
                        };
                    }
                }
            }

            return departments;
        }

        public void AddDepartment(Department department)
        {
            _departmentRepository.Add(department);

            var addedDepartments = GetDepartmentsByCustomerId(department.CustomerId);

            foreach (var addedDep in addedDepartments)
            {
                if (addedDep.Manager != null && 
                    addedDep.Address == department.Address 
                    && addedDep.Name == department.Name)
                {
                    var departmentUsers = _departmentUserRepository.GetById(addedDep.Id);
                    if (departmentUsers == null)
                    {
                        _departmentUserRepository.Add(new DepartmentUser()
                        {
                            DepartmentId = addedDep.Id,
                            UserId = department.ManagerId,
                            IsManager = true
                        });
                    }
                }
            }
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
