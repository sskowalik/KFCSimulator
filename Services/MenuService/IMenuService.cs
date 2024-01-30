using KFCSimulator.Models;
using System.Collections.Generic;

namespace KFCSimulator.Services.MenuService
{
    public interface IMenuService
    {
        MenuItem CreateMenuItem(string name, string description, decimal price, bool isActive);
        MenuItem GetMenuItemById(int menuItemId);
        bool UpdateMenuItem(int menuItemId, MenuItem updatedMenuItem);
        bool DeleteMenuItem(int menuItemId);
        IEnumerable<MenuItem> GetAllMenuItems();
    }
}
