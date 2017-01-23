using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivelyServedPizza.Models;
using ActivelyServedPizza.Models.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PizzaSharp.Interfaces;
using PizzaSharp.Models;

namespace ActivelyServedPizza.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IItemRepository _itemRepository;

        public CartController(UserManager<ApplicationUser> userManager, 
            IOrderRepository orderRepository, IPizzaRepository pizzaRepository, IItemRepository itemRepository)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
            _itemRepository = itemRepository;
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

            AddOrder(order);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PlaceOrder()
        {
            Order order = await GetOrder();

            int n = order.Items.Count;
            for (int i = 0; i < n; ++i)
            {
                order.Items[i].Product = _pizzaRepository.Get(order.Items[i].Product.ProductId);
            }

            _orderRepository.Add(order);
            HttpContext.Session.Remove("cart");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrder(OrderViewModel orderModel)
        {
            Order order = await GetOrder();

            Pizza pizza = _pizzaRepository.Get(Guid.Parse(orderModel.PizzaId));

            Item item = new Item();
            item.Amount = orderModel.Amount;
            item.ItemId = Guid.NewGuid();
            item.Product = pizza;
            item.Size = orderModel.Size;

            order.Items.Add(item);

            AddOrder(order);

            return RedirectToAction("Index");
        }

        private void AddOrder(Order order)
        {
            var orderString = JsonConvert.SerializeObject(order);
            HttpContext.Session.SetString("cart", orderString);
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
                order = JsonConvert.DeserializeObject<Order>(sessionString, new ProductConverter());
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
