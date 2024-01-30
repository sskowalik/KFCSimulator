using KFCSimulator.Models;
using KFCSimulator.Services.MenuService;
using System;
using System.Collections.Generic;

namespace KFCSimulator.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private static int _lastOrderId = 0;
        private static readonly List<Order> _orders = new List<Order>();
        private readonly IMenuService _menuService;

        public OrderService(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public Order CreateOrder(int customerId, List<int> menuItemIds)
        {
            var orderItems = new List<OrderItem>();
            foreach (var menuItemId in menuItemIds)
            {
                var menuItem = _menuService.GetMenuItemById(menuItemId);
                if (menuItem == null)
                {
                    throw new MenuItemNotFoundException(menuItemId);
                }
                
                orderItems.Add(new OrderItem
                {
                    MenuItemId = menuItem.Id,
                    Quantity = 1,
                    Price = menuItem.Price
                });
            }

            var newOrder = new Order
            {
                Id = GenerateOrderId(),
                CustomerId = customerId,
                OrderTime = DateTime.Now,
                Items = orderItems,
                TotalPrice = CalculateTotalPrice(orderItems),
                IsCompleted = false
            };
            _orders.Add(newOrder);

            return newOrder;
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.Find(order => order.Id == orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }

        private int GenerateOrderId()
        {
            _lastOrderId++;
            return _lastOrderId;
        }

        private decimal CalculateTotalPrice(List<OrderItem> items)
        {
            decimal totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.Price * item.Quantity;
            }
            return totalPrice;
        }
    }

    public class MenuItemNotFoundException : Exception
    {
        public MenuItemNotFoundException(int menuItemId) 
            : base($"Menu item with id {menuItemId} not found.")
        {
        }


    }
}
