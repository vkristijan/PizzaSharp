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

    }
}
