using System;
using System.Collections.Generic;
using KFCSimulator.Models;

namespace KFCSimulator.Services.ShiftService
{
    public interface IShiftService
    {
        Shift CreateShift(int employeeId, DateTime startTime, DateTime endTime, decimal hourlyRate);
        Shift GetShiftById(int shiftId);
        IEnumerable<Shift> GetAllShifts();
        decimal CalculateSalary(DateTime startTime, DateTime endTime, decimal hourlyRate);
    }
}
