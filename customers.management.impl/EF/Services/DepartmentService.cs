﻿using System.Collections.Generic;
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
            if (departments != null)
            {
                foreach (var dep in departments)
                {
                    if (dep.Id == 0)
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
        }

        public void DeleteDepartments(List<Department> departments)
        {
            if (departments != null)
            {
                foreach (var dep in departments)
                {
                    _departmentRepository.Delete(dep.Id);
                }

                _departmentRepository.Save();
            }
        }
    }
}
