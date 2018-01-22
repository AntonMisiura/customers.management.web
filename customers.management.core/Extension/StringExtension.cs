using customers.management.core.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace customers.management.core.Extension
{
    public static class StringExtension
    {
        public static string CreateHash(this string str)
        {
            return PasswordHasher.CreateHash(str);
        }
    }
}
