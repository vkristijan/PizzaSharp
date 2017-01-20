using System;
using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
{
    public interface IDrinkRepository
    {
        List<Drink> GetAll();

        void Add(Drink drink);

        Drink Get(Guid drinkId);
    }
}
