using System;
using System.Collections.Generic;
using System.Linq;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace PizzaSharp.SqlRepositories
{
    public class ItemSqlRepository : IItemRepository
    {
        private readonly PizzaDbContext _context;

        public ItemSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public void Add(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Item oldItem = Get(item.ItemId);

            if (oldItem == null)
            {
                _context.Items.Add(item);
            }
            else
            {
                item.UpdateValues(item);
            }
            _context.SaveChanges();
        }

        public Item Get(Guid itemId)
        {
            return _context
                .Items
                .SingleOrDefault(i => i.ItemId == itemId);
        }

        public List<Item> GetAll(Guid orderId)
        {
            return _context
                .Items
                .Where(i => i.Order.OrderId == orderId)
                .ToList();
        }

        public bool Remove(Item item)
        {
            Item oldItem = Get(item.ItemId);

            if (oldItem == null)
            {
                return false;
            }

            _context.Items.Remove(oldItem);
            _context.SaveChanges();
            return true;
        }
    }
}
