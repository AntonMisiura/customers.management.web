using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(CancellationToken token, string login);
    }
}
