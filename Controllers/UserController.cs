using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KFCSimulator.Models;
using KFCSimulator.Services;

namespace KFCSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserCreateRequest request)
        {
            var newUser = _userService.CreateUser(
                request.Name,
                request.Surname,
                request.Password,
                request.Birthdate,
                request.HireDate
            );

            return Ok(new { Message = "User created successfully", UserId = newUser.Id });
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut("{userId}/update")]
        public IActionResult UpdateUser(int userId, [FromBody] UserUpdateRequest request)
        {
            var updatedUser = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                Birthdate = request.Birthdate,
                HireDate = request.HireDate
            };

            var result = _userService.UpdateUser(userId, updatedUser);

            if (result)
                return Ok(new { Message = "User updated successfully" });
            else
                return NotFound(new { Message = "User not found" });
        }

        [HttpDelete("{userId}/delete")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _userService.DeleteUser(userId);

            if (result)
                return Ok(new { Message = "User deleted successfully" });
            else
                return NotFound(new { Message = "User not found" });
        }
    }

    public class UserCreateRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(50, ErrorMessage = "Surname cannot be longer than 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime Birthdate { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class UserUpdateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime HireDate { get; set; }
    }
}