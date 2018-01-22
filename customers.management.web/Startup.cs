using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using customers.management.impl.EF;
using customers.management.impl.EF.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace customers.management.web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<CustomersContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();

            app.UseStaticFiles();

#pragma warning disable 618
            app.UseIdentity();
#pragma warning restore 618

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = { "Admin", "User"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var admin = new User
            {
                UserName = Configuration.GetSection("UserSettings")["Username"],
                Email = Configuration.GetSection("UserSettings")["Useremail"]
            };

            var userPassword = Configuration.GetSection("UserSettings")["Password"];
            var user = await userManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["Useremail"]);

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(admin, userPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
