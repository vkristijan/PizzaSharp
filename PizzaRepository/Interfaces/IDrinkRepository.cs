using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
