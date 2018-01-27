using System.Collections.Generic;
using System.Threading;
using customers.management.core.Contracts;
using customers.management.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace customers.management.web.Controllers
{
    [Route("[controller]/[action]")]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetByCustomerId(int id)
        {
            var departments = _departmentService.GetDepartmentsByCustomerId(id);
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] Department department)
        {
            _departmentService.AddDepartment(department);
            return Ok(department.Name);
        }

        [HttpPost]
        public IActionResult EditDepartment([FromBody] Department department)
        {
            _departmentService.EditDepartment(department);
            return Ok(department.Name);
        }

        [HttpGet("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}
