using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
{
    public interface IIngredientRepository
    {
        Ingredient Get(Ingredient ingredient);

        List<Ingredient> GetAll();

        void Add(Ingredient ingredient);

        void Update(Ingredient ingredient);
    }
}
