using System;
using System.Collections.Generic;
using System.Linq;
using KFCSimulator.Models;

namespace KFCSimulator.Services.ShiftService
{
    public class ShiftService : IShiftService
    {
        private static int _lastShiftId = 0;
        private static readonly List<Shift> _shifts = new List<Shift>();
        private readonly IUserService _userService;

        public ShiftService(IUserService userService)
        {
            _userService = userService;
        }
        public Shift CreateShift(int employeeId, DateTime startTime, DateTime endTime, decimal hourlyRate)
        {
            var existingUser = _userService.GetUserById(employeeId);

            if (existingUser == null)
            {
                return null;
            }

            var newShift = new Shift
            {
                Id = GenerateShiftId(),
                EmployeeId = employeeId,
                StartTime = startTime,
                EndTime = endTime,
                HourlyRate = hourlyRate
            };
            _shifts.Add(newShift);

            return newShift;
        }

        public Shift GetShiftById(int shiftId)
        {
            return _shifts.FirstOrDefault(s => s.Id == shiftId);
        }

        public IEnumerable<Shift> GetAllShifts()
        {
            return _shifts;
        }

        public decimal CalculateSalary(DateTime startTime, DateTime endTime, decimal hourlyRate)
        {
            TimeSpan duration = endTime - startTime;
            decimal salary = (decimal)duration.TotalHours * hourlyRate;
            return salary;
        }

        private int GenerateShiftId()
        {
            _lastShiftId++;
            return _lastShiftId;
        }
    }
}
