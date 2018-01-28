using customers.management.core.Contracts;
using customers.management.core.dto;
using customers.management.core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerDetailsController : Controller
    {
        private ILoginService _loginService;
        private ICustomerDetailsService _customerDetailsService;

        public CustomerDetailsController(ICustomerDetailsService customerDetailsService,
            ILoginService loginService)
        {
            _customerDetailsService = customerDetailsService;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            if (!_loginService.IsCurrentUserAdmin())
            {
                return Forbid();
            }

            return Ok(_customerDetailsService.GetAllCustomerDetails());
        }

        [HttpGet]
        public IActionResult GetCustomerDetailsById(int id)
        {
            if (!_loginService.IsCurrentUserAdmin())
            {
                return Forbid();
            }

            return Ok(_customerDetailsService.GetCustomerDetailsById(id));
        }

        [HttpGet]
        public IActionResult GetCustomerByUserName(string userName)
        {
            return Ok(_customerDetailsService.GetCustomerDetailsByUserName(userName));
        }

        [HttpPost]
        public IActionResult SaveCustomerDetails(CustomerDetails details)
        {
            if (!_loginService.IsCurrentUserAdmin())
            {
                return Forbid();
            }

            _customerDetailsService.SaveCustomerDetails(details);

            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteCustomerDetails(CustomerDetails details)
        {
            if (!_loginService.IsCurrentUserAdmin())
            {
                return Forbid();
            }

            _customerDetailsService.DeleteCustomerDetails(details);

            return Ok();
        }
    }
}
