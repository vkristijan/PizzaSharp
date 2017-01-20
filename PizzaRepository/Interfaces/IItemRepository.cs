using System;
using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
{
    public interface IItemRepository
    {
        void Add(Item item);
        Item Get(Guid itemId);
        List<Item> GetAll(Guid orderId);
        bool Remove(Item item);
    }
}
