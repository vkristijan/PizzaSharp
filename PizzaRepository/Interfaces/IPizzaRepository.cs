using PizzaSharp.Models;
using System;
using System.Collections.Generic;

namespace PizzaSharp
{
    public interface IPizzaRepository
    {
        Pizza Get(Guid productId);
        List<Pizza> GetAll(Guid user, bool isCreatedByAdmin);
        void Add(Pizza pizza);
        void Update(Pizza other);
        void Remove(Pizza pizza);        
    }   
}