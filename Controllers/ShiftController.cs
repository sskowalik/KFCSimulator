using Microsoft.AspNetCore.Mvc;
using System;
using KFCSimulator.Models;
using KFCSimulator.Services.ShiftService;

namespace KFCSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpPost("create")]
        public IActionResult CreateShift([FromBody] ShiftCreateRequest request)
        {
            var newShift = _shiftService.CreateShift(
                request.EmployeeId,
                request.StartTime,
                request.EndTime,
                request.HourlyRate
            );

            if (newShift == null)
            {
                return NotFound(new { Message = "Employee not found" });
            }

            return Ok(new { Message = "Shift created successfully", ShiftId = newShift.Id });
        }

        [HttpGet("all")]
        public IActionResult GetAllShifts()
        {
            var shifts = _shiftService.GetAllShifts();
            return Ok(shifts);
        }

        [HttpGet("{shiftId}/salary")]
        public IActionResult CalculateSalary(int shiftId)
        {
            var shift = _shiftService.GetShiftById(shiftId);
            if (shift == null)
            {
                return NotFound(new { Message = "Shift not found" });
            }

            decimal salary = _shiftService.CalculateSalary(shift.StartTime, shift.EndTime, shift.HourlyRate);
            return Ok(new { Salary = salary });
        }
    }
}
