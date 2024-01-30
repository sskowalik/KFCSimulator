using System;
using System.Collections.Generic;
using KFCSimulator.Models;

namespace KFCSimulator.Services.UserService
{
    public interface IUserService
    {
        User CreateUser(string name, string surname, string password, DateTime birthdate, DateTime hireDate);
        User GetUserById(int userId);
        bool UpdateUser(int userId, User updatedUser);
        bool DeleteUser(int userId);
        IEnumerable<User> GetUsers();
    }
}
