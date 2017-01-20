using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public abstract class Product 
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int PriceSmall { get; set; }
        public int PriceMedium { get; set; }
        public int PriceBig { get; set; }
        public string PhotoName { get; set; }
    }
}
