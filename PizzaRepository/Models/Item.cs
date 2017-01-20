using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Item
    {
        public int Amount { get; set; }
        public Product Product { get; set; }
        public int Size { get; set; }

    }
}
