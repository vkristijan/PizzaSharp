using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace PizzaSharp.SqlRepositories
{
    public class DrinkSqlRepository : IDrinkRepository
    {
        private PizzaDbContext _context;

        public DrinkSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public List<Drink> GetAll()
        {
            return _context
                .Products
                .OfType<Drink>()
                .ToList();
        }

        public void Add(Drink drink)
        {
            if (drink == null)
            {
                throw new ArgumentNullException("The given drink is null!");
            }

            Drink oldDrink = Get(drink.ProductId);

            if (oldDrink == null)
            {
                _context.Products.Add(drink);
            }
            else
            {
                oldDrink.UpdateValues(drink);
            }
            _context.SaveChanges();
        }

        public Drink Get(Guid drinkId)
        {
            return _context
                .Products
                .OfType<Drink>()
                .SingleOrDefault(d => d.ProductId == drinkId);
        }
    }
}
