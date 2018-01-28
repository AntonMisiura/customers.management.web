﻿using System.Security.Claims;
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
    public class UserController : Controller
    {
        private IUserService _userService;
        public IConfiguration Configuration { get; }

        public UserController(IConfiguration configuration, IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetByCustomerId(int id)
        {
            var users = _userService.GetUsersByCustomerId(id);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user != null)
            {
                _userService.AddUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult EditUser([FromBody] User user)
        {
            if (user != null)
            {
                _userService.EditUser(user);
                return Ok(user.Name);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("id")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return Ok("Url saved");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDetails user)
        {
            const string badUserNameOrPasswordMessage = "Username or password is incorrect.";

            if (user == null)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            var dbUser = _userService.GetByLogin(user.UserName);

            if (dbUser != null)
            {
                if (user.Password == dbUser.Password)
                {
                    dbUser.Password = string.Empty;
                }
                else
                {
                    return BadRequest(badUserNameOrPasswordMessage);
                }
            }
            else
            {
                var admin = new AdminAccount(Configuration);

                if (user.UserName == admin.UserName &&
                    user.Password == admin.Password)
                {
                    var adminIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    adminIdentity.AddClaim(new Claim(ClaimTypes.Name, admin.UserName));

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(adminIdentity));

                    return Ok(admin.UserName);
                }
                else
                {
                    return BadRequest(badUserNameOrPasswordMessage);
                }
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, dbUser.UserName));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return Ok(dbUser.CustomerId);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
