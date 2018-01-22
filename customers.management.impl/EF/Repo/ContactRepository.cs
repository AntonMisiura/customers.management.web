﻿using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Repo
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(CustomersContext context) : base(context)
        {
        }
    }
}
