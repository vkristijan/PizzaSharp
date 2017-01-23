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
using ActivelyServedPizza.Models.OrderViewModels;

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
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, Roles.Admin);

            List<Pizza> list = _repository
                .GetAll(Guid.Parse(currentUser.Id), isAdmin)
                .OrderBy(p => p.IsCreatedByAdmin)
                .ToList();

            ApplicationUser userX = await _userManager.FindByIdAsync(currentUser.Id);

            return View(list);
        }


        public IActionResult Show(Guid pizzaId)
        {
            Pizza pizza = _repository.Get(pizzaId);

            OrderViewModel model = new OrderViewModel();
            model.Pizza = pizza;

            return View(model);
        }
    }
}
