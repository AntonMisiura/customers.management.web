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
    [Authorize(Policy = "RequireAdminRole")]
    public class ContactController : Controller
    {
        private IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("contacts/{id:int}")]
        public IEnumerable<Contact> GetContactsByCustomerId(CancellationToken token, int id)
        {
            return _repository.GetByCustomerId(token, id);
        }

        [HttpPost("")]
        public IActionResult AddContact(CancellationToken token, [FromBody] Contact contact)
        {
            _repository.Add(token, contact);
            return Ok();
        }

        [HttpPost("")]
        public IActionResult EditContact(CancellationToken token, [FromBody] Contact contact)
        {
            _repository.Edit(token, contact);
            return Ok();
        }

        [HttpGet("contacts/{id:int}")]
        public IActionResult DeleteContact(CancellationToken token, int id)
        {
            _repository.Delete(token, id);
            return Ok();
        }
    }
}
