using Microsoft.AspNetCore.Mvc;
using KFCSimulator.Models;
using KFCSimulator.Services.OrderService;
using System;
using System.Collections.Generic;

namespace KFCSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] OrderCreateRequest request)
        {
            var newOrder = _orderService.CreateOrder(
                request.CustomerId,
                request.MenuItemIds
            );

            return Ok(new { Message = "Order created successfully", OrderId = newOrder.Id });
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound(new { Message = "Order not found" });
            }
            return Ok(order);
        }

        [HttpGet("all")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }
    }

    public class OrderCreateRequest
    {
        public int CustomerId { get; set; }
        public List<int> MenuItemIds { get; set; }
    }
}