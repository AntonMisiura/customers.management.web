using System.Collections.Generic;
using System.Threading;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("departments/{id:int}")]
        public IEnumerable<Department> GetDepartmentsByCustomerId(CancellationToken token, int id)
        {
            return _repository.GetByCustomerId(token, id);
        }

        [HttpPost("")]
        public IActionResult AddDepartment(CancellationToken token, [FromBody] Department department)
        {
            _repository.Add(token, department);
            return Ok();
        }

        [HttpPost("")]
        public IActionResult EditDepartment(CancellationToken token, [FromBody] Department department)
        {
            _repository.Edit(token, department);
            return Ok();
        }

        [HttpGet("departments/{id:int}")]
        public IActionResult DeleteDepartment(CancellationToken token, int id)
        {
            _repository.Delete(token, id);
            return Ok();
        }
    }
}
