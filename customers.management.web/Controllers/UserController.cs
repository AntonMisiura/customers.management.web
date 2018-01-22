using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using customers.management.core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("users/{id:int}")]
        public IEnumerable<User> GetUsersByCustomerId(CancellationToken token, int id)
        {
            return _repository.GetByCustomerId(token, id);
        }

        [HttpPost("")]
        public IActionResult AddUser(CancellationToken token, [FromBody] User user)
        {
            _repository.Add(token, user);
            return Ok(user.Name);
        }

        [HttpPost("")]
        public IActionResult EditUser(CancellationToken token, [FromBody] User user)
        {
            _repository.Edit(token, user);
            return Ok();
        }

        [HttpGet("users/{id:int}")]
        public IActionResult DeleteUser(CancellationToken token, int id)
        {
            _repository.Delete(token, id);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(CancellationToken token, [FromBody]User user)
        {
            if (user == null)
                return NotFound("User doesn't exist");

            var dbUser = _repository.GetByLogin(token, user.UserName);
            if (PasswordHasher.ValidatePassowrd(user.Password, dbUser.Password))
            {
                dbUser.Password = string.Empty;
                return Ok(dbUser);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
