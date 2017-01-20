using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp.Models
{
    public class Comment
    {
        public string Text { get; set; }
        public Pizza Pizza { get; set; }
        public Guid User { get; set; }
    }
}
