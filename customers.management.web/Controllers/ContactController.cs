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
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] Contact contact)
        {
            _contactService.AddContact(contact);
            return Ok(contact.Name);
        }

        [HttpPost]
        public IActionResult EditContact([FromBody] Contact contact)
        {
           _contactService.EditContact(contact);
            return Ok(contact.Name);
        }

        [HttpGet("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return Ok();
        }
    }
}
