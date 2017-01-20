using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Review
    {
        public Pizza Pizza { get; set; }
        public Guid User { get; set; }
        public int Grade { get; set; }
    }
}
