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
        public bool IsCreatedByAdmin { get; set; }

        public void UpdateValues(Pizza other)
        {
            if(ProductId != other.ProductId  ||  User != other.User)
            {
                throw new ArgumentException("Not allowed to update given pizza!");
            }

            Ingredients = other.Ingredients;

            base.UpdateValues(other);
        }
    }
}