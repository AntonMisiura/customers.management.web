using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace customers.management.impl.EF.Services
{
    public class LoginService : ILoginService
    {
        private readonly AdminAccount _admin;
        private readonly IUserService _userService;
        private const string RoleAdmin = "Admin";
        private const string RoleUser = "User";

        public LoginService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _admin = new AdminAccount(configuration);
        }

        private bool IsAdmin(UserDetails user)
        {
            return (user.UserName == _admin.UserName &&
                    user.Password == _admin.Password);
        }

        public ClaimsIdentity Authorize(UserDetails user)
        {
            var claimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            if (IsAdmin(user))
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Name, _admin.UserName));
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, RoleAdmin));
                user.IsAdmin = true;
            }
            else
            {
                var dbUser = _userService.GetByLogin(user.UserName);

                if (dbUser != null)
                {
                    if (user.Password == dbUser.Password)
                    {
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Name, dbUser.UserName));
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Role, RoleUser));
                    }
                }
            }

            var allClaims = claimIdentity.Claims;

            if (!allClaims.Any())
            {
                throw new AuthenticationException("Username or password is incorrect.");
            }

            return claimIdentity;
        }

        public List<Claim> GetCurrentUserIdentity()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            return identity.Claims.ToList();
        }

        public bool IsCurrentUserAdmin()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var role = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).First();

            return RoleAdmin.Equals(role);
        }
    }
}
