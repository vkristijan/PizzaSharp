using PizzaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivelyServedPizza.Models.OrderViewModels
{
    public class OrderViewModel
    {
        public Pizza Pizza {get; set; }
        public int Size { get; set; }
        public int Amount { get; set; }
    }
}
