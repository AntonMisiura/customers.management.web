using System;
using System.Collections.Generic;
using System.Text;

namespace customers.management.impl.EF.Repo
{
    public class BaseRepository
    {
        protected CustomersContext Context { get; private set; }

        protected BaseRepository(CustomersContext context)
        {
            Context = context;
        }
    }
}
