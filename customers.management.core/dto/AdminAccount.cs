using Microsoft.Extensions.Configuration;

namespace customers.management.core.dto
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
