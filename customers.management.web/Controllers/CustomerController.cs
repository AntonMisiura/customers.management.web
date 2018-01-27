using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerContacts(int id)
        {
            return Ok(_customerService.GetCustomerContacts(id));
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok(customer.Name);
        }

        [HttpPost]
        public IActionResult EditCustomer([FromBody] Customer customer)
        {
            _customerService.EditCustomer(customer);
            return Ok(customer.Name);
        }

        [HttpGet("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
