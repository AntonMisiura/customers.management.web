using customers.management.core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("id")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
