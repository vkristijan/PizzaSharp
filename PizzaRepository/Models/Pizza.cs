using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaSharp.Models
{
    public class Pizza : Product
    {
        public List<Ingredient> Ingredients {get; set;}
        public Guid User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public bool isCreatedByAdmin { get; set; }

        public void UpdateValues(Pizza other)
        {
            if(this.ProductId != other.ProductId  ||  this.User != other.User)
            {
                throw new ArgumentException("Not allowed to update given pizza!");
            }

            this.Name = other.Name;
            this.Ingredients = other.Ingredients;
            this.PhotoName = other.PhotoName;
            this.PriceBig = other.PriceBig;
            this.PriceMedium = other.PriceMedium;
            this.PriceSmall = other.PriceSmall;
        }
    }
}