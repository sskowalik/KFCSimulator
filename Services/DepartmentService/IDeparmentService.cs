using KFCSimulator.Models;
using System.Collections.Generic;

namespace KFCSimulator.Services.DepartmentService
{
    public interface IDepartmentService
    {
        IEnumerable<User> GetUsersInDepartment(Department department);
        void AssignUserToDepartment(int userId, Department department);
    }
}
