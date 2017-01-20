using System;
using System.Collections.Generic;
using System.Linq;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace PizzaSharp.SqlRepositories
{
    public class IngredientSqlRepository : IIngredientRepository
    {
        private readonly PizzaDbContext _context;
        public IngredientSqlRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public void Add(Ingredient ingredient)
        {
            Ingredient oldIngredient = Get(ingredient);

            if (oldIngredient == null)
                _context.Ingredients.Add(ingredient);
            else
                throw new ArgumentException("The given ingredient already exists!");

            _context.SaveChanges();
        }

        public Ingredient Get(Ingredient ingredient)
        {
            return _context
                .Ingredients
                .FirstOrDefault(s => s.Name.Equals(ingredient.Name));
        }

        public List<Ingredient> GetAll()
        {
            return _context
                .Ingredients
                .ToList();
        }

        public void Update(Ingredient ingredient)
        {
            Ingredient oldIngredient = Get(ingredient);

            if (oldIngredient != null)
                oldIngredient.UpdateValues(ingredient);
            else
                throw new ArgumentException("The given ingredient doesn't exist!");

            _context.SaveChanges();
        }
    }
}
