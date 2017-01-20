using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Order
    {
        public List<Item> Items { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid User { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryMessage { get; set; }
        public string DeliveryAddress { get; set; }
        public bool Delivery { get; set; }

    }
}
