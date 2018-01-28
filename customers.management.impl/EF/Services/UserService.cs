using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IDepartmentUserRepository _departmentUserRepository;
        private IDepartmentRepository _departmentRepository;

        public UserService(IUserRepository userRepository, 
            IDepartmentUserRepository departmentUserRepository, 
            IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentUserRepository = departmentUserRepository;
            _departmentRepository = departmentRepository;
        }

        public List<User> GetUsersByCustomerId(int id)
        {
            var users = _userRepository.GetByCustomerId(id);
            //var departments = _departmentRepository.GetByCustomerId(id);
            //var usersDepatments = _departmentUserRepository.GetAll();

            //foreach (var user in users)
            //{
            //    foreach (var dep in departments)
            //    {
            //        foreach (var userDeps in usersDepatments)
            //        {
            //            if (user.Id == userDeps.UserId 
            //                && dep.Id == userDeps.DepartmentId)
            //            {
            //                var department = _departmentRepository.GetById(userDeps.DepartmentId);

            //                user.Department = new Department()
            //                {
            //                    Name = department.Name,
            //                };
            //            }
            //        }
            //    }
            //}

            return users;
        }

        public void SaveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.Id == null)
                {
                    _userRepository.Edit(user);
                }
                else
                {
                    _userRepository.Add(user);
                }
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}
