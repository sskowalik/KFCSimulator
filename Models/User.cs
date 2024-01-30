using System;

namespace KFCSimulator.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
    }
}
