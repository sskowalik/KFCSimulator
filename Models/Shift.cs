using System;

namespace KFCSimulator.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
