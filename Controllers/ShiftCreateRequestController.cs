using System;

namespace KFCSimulator.Controllers
{
    public class ShiftCreateRequest
    {
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
