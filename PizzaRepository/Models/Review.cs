using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public Pizza Pizza { get; set; }
        public Guid User { get; set; }
        public int Grade { get; set; }

        public void UpdateValues(Review review)
        {
            if (ReviewId != review.ReviewId || Pizza.ProductId != review.Pizza.ProductId || User != review.User)
            {
                throw new ArgumentException("Not allowed to update given review!");
            }

            Grade = review.Grade;
        }
    }
}
