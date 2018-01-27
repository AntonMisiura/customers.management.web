using System;
using System.Collections.Generic;
using System.Text;
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
        /// add user
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);

        /// <summary>
        /// edit user
        /// </summary>
        /// <param name="user"></param>
        void EditUser(User user);

        /// <summary>
        /// delete user by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);

        /// <summary>
        /// get user by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetByLogin(string login);
    }
}
