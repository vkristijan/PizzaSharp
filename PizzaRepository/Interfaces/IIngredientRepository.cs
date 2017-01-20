using PizzaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSharp
{
    public interface IIngredientRepository
    {
        Ingredient Get(Ingredient ingredient);

        List<Ingredient> GetAll();

        void Add(Ingredient ingredient);

        void Update(Ingredient ingredient);
    }
}
