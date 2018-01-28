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

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
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

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}
