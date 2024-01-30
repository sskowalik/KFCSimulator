using System;
using System.Collections.Generic;
using System.Linq;
using KFCSimulator.Models;

namespace KFCSimulator.Services.UserService
{
    public class UserService : IUserService
    {
        private static int _lastUserId = 0;
        private static readonly List<User> _users = new List<User>();

        public User CreateUser(string name, string surname, string password, DateTime birthdate, DateTime hireDate)
        {
            var newUser = new User
            {
                Id = GenerateUserId(),
                Name = name,
                Surname = surname,
                Password = password,
                Birthdate = birthdate,
                HireDate = hireDate
            };
            _users.Add(newUser);

            return newUser;
        }

        public User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public bool UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == userId);

            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Surname = updatedUser.Surname;
                existingUser.Password = updatedUser.Password;
                existingUser.Birthdate = updatedUser.Birthdate;
                existingUser.HireDate = updatedUser.HireDate;

                return true;
            }

            return false;
        }

        public bool DeleteUser(int userId)
        {
            var userToRemove = _users.FirstOrDefault(u => u.Id == userId);

            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
                return true;
            }

            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        private int GenerateUserId()
        {
            _lastUserId++;
            return _lastUserId;
        }
    }
}