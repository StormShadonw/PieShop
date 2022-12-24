using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.Repositories.Interfaces;

namespace PieShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCart shoppingCart;

        public OrderController(IOrderRepository _orderRepository, IShoppingCart _shoppingCart)
        {
            orderRepository = _orderRepository;
            shoppingCart = _shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.shoppingCartItems = items;

            if(shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first.");
            }
            if(ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            else
            {
                ModelState.AddModelError("", ModelState.ValidationState.ToString());
            }

            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
