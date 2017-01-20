using PizzaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp
{
    public interface IOrderRepository 
    {
        Order Get(Guid orderId);

        List<Order> GetAll(Guid userId, bool isAdmin);

        void Update(Guid userId, Order order);
    }
}
