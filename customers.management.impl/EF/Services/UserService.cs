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
            if (users != null)
            {
                foreach (var user in users)
                {
                    if (user.Id == 0)
                    {
                        _userRepository.Add(user);
                    }
                    else
                    {
                        _userRepository.Edit(user);
                    }
                }

                _userRepository.Save();
            }
        }


        public void DeleteUsers(List<User> users)
        {
            if (users != null)
            {
                foreach (var user in users)
                {
                    _userRepository.Delete(user.Id);
                }

                _userRepository.Save();
            }
        }

        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}
