using PizzaSharp.Models;
using System;

namespace PizzaSharp
{
    public interface IPizzaRepository
    {
        void Add(Pizza pizza);
        void Update(Pizza other);
    }   
}