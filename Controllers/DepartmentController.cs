using Microsoft.AspNetCore.Mvc;
using KFCSimulator.Models;
using KFCSimulator.Services.DepartmentService;
using System;
using System.Collections.Generic;

namespace KFCSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{department}")]
        public IActionResult GetUsersInDepartment(Department department)
        {
            try
            {
                var users = _departmentService.GetUsersInDepartment(department);
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{userId}/assign/{department}")]
        public IActionResult AssignUserToDepartment(int userId, Department department)
        {
            try
            {
                _departmentService.AssignUserToDepartment(userId, department);
                return Ok("User assigned to department successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
