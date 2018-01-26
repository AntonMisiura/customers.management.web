using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using customers.management.impl.EF;
using customers.management.impl.EF.Repo;
using customers.management.impl.EF.Services;
using customers.management.web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            services.AddDbContext<CustomersContext>(options =>
                options.UseSqlServer(connection));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ICustomerContactRepository, CustomerContactRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = new PathString("/login"));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            services.AddMvc();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();

            //app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
