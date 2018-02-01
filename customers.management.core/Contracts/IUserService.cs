using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// get list of users by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<User> GetUsersByCustomerId(int id);

        /// <summary>
        /// get by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);

        /// <summary>
        /// edit and delete users
        /// </summary>
        /// <param name="users"></param>
        void SaveUsers(List<User> users);

        /// <summary>
        /// delete list of users
        /// </summary>
        /// <param name="users"></param>
        void DeleteUsers(List<User> users);

        /// <summary>
        /// get user by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetByLogin(string login);
    }
}
