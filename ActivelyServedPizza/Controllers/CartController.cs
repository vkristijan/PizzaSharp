using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivelyServedPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace ActivelyServedPizza.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderRepository _orderRepository;

        public CartController(UserManager<ApplicationUser> userManager, IOrderRepository orderRepository)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
        }


        public async Task<IActionResult> Index()
        {
            Order order = await GetOrder();            
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Order updatedOrder)
        {
            Order order = await GetOrder();

            order.Delivery = updatedOrder.Delivery;
            order.DeliveryAddress = updatedOrder.DeliveryAddress;
            order.DeliveryMessage = updatedOrder.DeliveryMessage;

            var orderString = JsonConvert.SerializeObject(order);
            HttpContext.Session.SetString("cart", orderString);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PlaceOrder()
        {
            Order order = await GetOrder();
            _orderRepository.Add(order);
            HttpContext.Session.Remove("cart");

            return RedirectToAction("Index");
        }

        private async Task<Order> GetOrder()
        {
            var sessionString = HttpContext.Session.GetString("cart");

            Order order;
            if (sessionString == null)
            {
                var currentUser = _userManager.GetUserAsync(HttpContext.User);
                order = new Order();
                order.OrderId = Guid.NewGuid();
                order.DateCreated = DateTime.Now;
                order.DeliveryDate = DateTime.Now;
                order.DeliveryAddress = "";
                order.Items = new List<Item>();
                order.User = Guid.Parse((await currentUser).Id);
            }
            else
            {
                order = JsonConvert.DeserializeObject<Order>(sessionString);
            }

            return order;
        }

        public async Task<IActionResult> AllOrders(Guid userId)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, Roles.Admin);

            List<Order> list = _orderRepository
                .GetAll(Guid.Parse(currentUser.Id), isAdmin)
                .ToList();

            return View(list);
        }
    }
}
