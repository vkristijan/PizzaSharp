using PizzaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp
{
    class PizzaSqlRepository : IPizzaRepository
    {
        private readonly PizzaDbContext _context;

        public PizzaSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public void Add(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }
            if (_context.Products.Any(s => s.Name == pizza.Name))
            {
                throw new Exception("The same pizza already exists.");
            }

            _context.Products.Add(pizza);
            _context.SaveChanges();
        }

        public void Update(Pizza other)
        {
            throw new NotImplementedException();
        }
    }
}

