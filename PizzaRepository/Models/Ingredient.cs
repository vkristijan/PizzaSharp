using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string PhotoName { get; set; }
        public int Price { get; set; }

        public void UpdateValues(Ingredient ingredient)
        {
            PhotoName = ingredient.PhotoName;
            Price = ingredient.Price;
        }
    }
}
