using System;
using System.Collections.Generic;
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

        public List<User> GetUsersByCustomerId(int id)
        {
            return _userRepository.GetByCustomerId(id);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void SaveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.Id == null)
                {
                    _userRepository.Add(user);
                }
                else
                {
                    _userRepository.Edit(user);
                }
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public void DeleteUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.Id != null) _userRepository.Delete((int) user.Id);
            }
        }

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}
