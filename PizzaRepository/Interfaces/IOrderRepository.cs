using System;
using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
{
    public interface IOrderRepository 
    {
        Order Get(Guid orderId);

        List<Order> GetAll(Guid userId, bool isAdmin);

        void Update(Guid userId, Order order);
    }
}
