﻿using System;
using System.Collections.Generic;
using System.Linq;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace PizzaSharp.SqlRepositories
{
    public class OrderSqlRepository : IOrderRepository
    {
        private readonly PizzaDbContext _context;

        public OrderSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public Order Get(Guid orderId)
        {
            return _context
                .Orders
                .FirstOrDefault(s => s.OrderId == orderId);
        }

        public List<Order> GetAll(Guid userId, bool isAdmin)
        {
            if (isAdmin)
                return _context
                    .Orders
                    .ToList();
            else
                return _context
                    .Orders
                    .Where(s => s.User == userId)
                    .ToList();
        }

        public void Update(Guid userId, Order order)
        {
            Order oldOrder = Get(order.OrderId);

            if (oldOrder.User == userId)
                oldOrder.UpdateValues(order);
            else
                throw new ArgumentNullException(nameof(userId));
        }
    }
}