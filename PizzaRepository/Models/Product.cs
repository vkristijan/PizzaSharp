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

        public void UpdateValues(Product other)
        {
            if (other.ProductId != ProductId)
            {
                throw new ArgumentException("Not allowed to change this product!");
            }

            Name = other.Name;
            PriceSmall = other.PriceSmall;
            PriceMedium = other.PriceMedium;
            PriceBig = other.PriceBig;

            PhotoName = other.PhotoName;
        }
    }
}
