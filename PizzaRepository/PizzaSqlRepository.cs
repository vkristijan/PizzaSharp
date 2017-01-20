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

        public Pizza Get(Guid productId)
        {
            return _context
                .Products
                .OfType<Pizza>()
                .SingleOrDefault(c => c.ProductId == productId);
        }

        public List<Pizza> GetAll(Guid user, bool createdByAdmin)
        {
            if (createdByAdmin)
                return _context
                    .Products
                    .OfType<Pizza>()
                    .ToList();
            else
                return _context
                    .Products
                    .OfType<Pizza>()                
                    .Where(s => s.User == user || s.isCreatedByAdmin)
                    .ToList();
        }    

        public void Remove(Pizza pizza)
        {
            Pizza other = Get(pizza.ProductId);

            if (other != null)
            {
                _context.Products.Remove(pizza);
                _context.SaveChanges();
            }

        }

        public void Update(Pizza other)
        {
            // checking ownership
            Pizza pizza = Get(other.ProductId);

            if (pizza != null)
                pizza.UpdateValues(other);
            else
                Add(other);
        }
    }
}