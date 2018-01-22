﻿using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}