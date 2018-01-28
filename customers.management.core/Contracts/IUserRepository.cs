using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// get user by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetByLogin(string login);

        /// <summary>
        /// get users by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<User> GetByCustomerId(int id);
    }
}
