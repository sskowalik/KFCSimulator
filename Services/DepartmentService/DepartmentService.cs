using KFCSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KFCSimulator.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUserService _userService;

        public DepartmentService(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> GetUsersInDepartment(Department department)
        {
            var allUsers = _userService.GetUsers();
            return allUsers.Where(u => u.Department == department);
        }

        public void AssignUserToDepartment(int userId, Department department)
        {
            var user = _userService.GetUserById(userId);
            if (user != null)
            {
                user.Department = department;
                _userService.UpdateUser(userId, user); // Aktualizacja użytkownika w UserService
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }
    }
}
