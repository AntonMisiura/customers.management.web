using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace customers.management.web.Models
{
    public class AdminAccount
    {
        public IConfiguration Configuration { get; }

        public AdminAccount(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string UserName => Configuration.GetSection("UserSettings")["Username"];
        public string Password => Configuration.GetSection("UserSettings")["Password"];
    }
}
