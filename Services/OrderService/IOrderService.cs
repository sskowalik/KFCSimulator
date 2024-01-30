using KFCSimulator.Models;
using KFCSimulator.Services.MenuService;
using System;
using System.Collections.Generic;

namespace KFCSimulator.Services.OrderService
{
    public interface IOrderService
    {
        Order CreateOrder(int customerId, List<int> menuItemIds);
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetAllOrders();
    }
}