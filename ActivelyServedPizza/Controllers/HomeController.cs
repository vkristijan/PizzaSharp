using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivelyServedPizza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace ActivelyServedPizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IOrderRepository _orderRepository;

        public HomeController(UserManager<ApplicationUser> userManager, 
            IPizzaRepository pizzaRepository, IOrderRepository orderRepository)
        {
            _userManager = userManager;
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
        }


        public IActionResult Index()
        {
            List<Pizza> pizzas = GetBestSelling(6);

            return View(pizzas);
        }

        private List<Pizza> GetBestSelling(int count)
        {
            List<Order> orders = _orderRepository.GetAllFromPastWeek();

            var pizzaCount = new Dictionary<Pizza, int>();

            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    if (item.Product is Pizza)
                    {
                        Pizza pizza = (Pizza) item.Product;
                        if (!pizza.IsCreatedByAdmin) continue;
              
                        if (!pizzaCount.ContainsKey(pizza))
                        {
                            pizzaCount.Add(pizza, 0);
                        }
                        pizzaCount[pizza] += item.Amount;
                    }
                }
            }

            return
                pizzaCount.OrderByDescending(x => x.Value)
                    .Take(count)
                    .ToDictionary(x => x.Key, x => x.Value)
                    .Keys.ToList();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = Roles.Admin)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
