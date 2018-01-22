using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public Customer GetById(CancellationToken token, int id)
        {
            return _repository.GetById(token, id);
        }

        [HttpPost("")]
        public IActionResult AddCustomer(CancellationToken token, [FromBody] Customer customer)
        {
            _repository.Add(token, customer);
            return Ok();
        }

        [HttpPost("")]
        public IActionResult EditCustomer(CancellationToken token, [FromBody] Customer customer)
        {
            _repository.Edit(token, customer);
            return Ok();
        }

        [HttpGet("customers/{id:int}")]
        public IActionResult DeleteCustomer(CancellationToken token, int id)
        {
            _repository.Delete(token, id);
            return Ok();
        }
    }
}
