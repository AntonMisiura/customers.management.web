using System.Collections.Generic;
using System.Linq;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace customers.management.impl.EF.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CustomersContext context) : base(context)
        {
        }

        public User GetByLogin(string login)
        {
            return Context.Set<User>().FirstOrDefault(e => e.UserName == login);
        }

        public List<User> GetByCustomerId(int id)
        {
            return Context.Set<User>().Include(d => d.Department).Where(e => e.CustomerId == id).ToList();
        }
    }
}
