using KFCSimulator.Models;
using System;
using System.Collections.Generic;

namespace KFCSimulator.Services.MenuService
{
    public class MenuService : IMenuService
    {
        private static int _lastMenuItemId = 0;
        private static readonly List<MenuItem> _menuItems = new List<MenuItem>();

        public MenuItem CreateMenuItem(string name, string description, decimal price, bool isActive)
        {
            var newMenuItem = new MenuItem
            {
                Id = GenerateMenuItemId(),
                Name = name,
                Description = description,
                Price = price,
                IsActive = isActive,
                CreationDate = DateTime.Now
            };
            _menuItems.Add(newMenuItem);

            return newMenuItem;
        }

        public MenuItem GetMenuItemById(int menuItemId)
        {
            return _menuItems.Find(item => item.Id == menuItemId);
        }

        public bool UpdateMenuItem(int menuItemId, MenuItem updatedMenuItem)
        {
            var index = _menuItems.FindIndex(item => item.Id == menuItemId);
            if (index != -1)
            {
                _menuItems[index] = updatedMenuItem;
                return true;
            }
            return false;
        }

        public bool DeleteMenuItem(int menuItemId)
        {
            var menuItemToRemove = _menuItems.Find(item => item.Id == menuItemId);
            if (menuItemToRemove != null)
            {
                _menuItems.Remove(menuItemToRemove);
                return true;
            }
            return false;
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }

        private int GenerateMenuItemId()
        {
            _lastMenuItemId++;
            return _lastMenuItemId;
        }
    }
}
