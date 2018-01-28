using System.Security.Claims;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.dto;
using customers.management.core.Entities;
using customers.management.web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace customers.management.web.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserDetails user)
        {
            var identity = _loginService.Authorize(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            user.Password = string.Empty;
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
