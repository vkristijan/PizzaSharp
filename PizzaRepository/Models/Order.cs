using System;
using System.Collections.Generic;

namespace PizzaSharp.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public List<Item> Items { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid User { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryMessage { get; set; }
        public string DeliveryAddress { get; set; }
        public bool Delivery { get; set; }

        public void UpdateValues(Order order)
        {
            Items = order.Items;
            Delivery = order.Delivery;
            DeliveryAddress = order.DeliveryAddress;
            DeliveryDate = order.DeliveryDate;
            DeliveryMessage = DeliveryMessage;
        }
    }
}
