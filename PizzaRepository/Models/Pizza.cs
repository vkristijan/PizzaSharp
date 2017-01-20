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
        public List<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }

        public void UpdateValues(Pizza other)
        {
            this.Name = other.Name;
            this.Comments = other.Comments;
            this.Ingredients = other.Ingredients;
            this.PhotoName = other.PhotoName;
            this.PriceBig = other.PriceBig;
            this.PriceMedium = other.PriceMedium;
            this.PriceSmall = other.PriceSmall;
            this.ProductId = other.ProductId;
            this.Reviews = other.Reviews;
            this.User = other.User;
        }
    }
}
