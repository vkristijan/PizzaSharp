using System;
using System.Collections.Generic;
using PizzaSharp.Models;

namespace PizzaSharp.Interfaces
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