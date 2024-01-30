using Microsoft.AspNetCore.Mvc;
using KFCSimulator.Models;
using KFCSimulator.Services.MenuService;
using System;
using System.Collections.Generic;

namespace KFCSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost("create")]
        public IActionResult CreateMenuItem([FromBody] MenuItemCreateRequest request)
        {
            var newMenuItem = _menuService.CreateMenuItem(
                request.Name,
                request.Description,
                request.Price,
                request.IsActive
            );

            return Ok(new { Message = "Menu item created successfully", MenuItemId = newMenuItem.Id });
        }

        [HttpGet("all")]
        public IActionResult GetAllMenuItems()
        {
            var menuItems = _menuService.GetAllMenuItems();
            return Ok(menuItems);
        }
    }

    public class MenuItemCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
