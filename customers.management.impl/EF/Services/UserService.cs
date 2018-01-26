using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public List<User> GetUsersByCustomerId(int id)
        {
            var users = _userRepository.GetByCustomerId(id);
            return users;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void EditUser(User user)
        {
            _userRepository.Edit(user);
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
