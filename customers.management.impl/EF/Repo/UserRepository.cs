using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CustomersContext context) : base(context)
        {
        }

        public User GetByLogin(CancellationToken token, string login)
        {
            return Context.Set<User>().FirstOrDefault(e => e.UserName == login);
        }
    }
}
