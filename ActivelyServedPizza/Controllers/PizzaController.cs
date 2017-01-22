using ActivelyServedPizza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivelyServedPizza.Controllers
{
    [Authorize]
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        // Inject user manager into constructor
        public PizzaController(IPizzaRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Offer()
        {
            bool isAdmin = false;
            
            // check if the user is admin !

            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            List<Pizza> list = _repository.GetAll(Guid.Parse(currentUser.Id), isAdmin);

            return View(list);
        }


        public IActionResult Show(Guid pizzaId)
        {
            Pizza pizza = _repository.Get(pizzaId);

            return View(pizza);
        }
    }
}
