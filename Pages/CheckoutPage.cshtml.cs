using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PieShop.Models;
using PieShop.Repositories.Interfaces;

namespace PieShop.Pages
{
    public class CheckoutPageModel : PageModel
    {

        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCart shoppingCart;
        [BindProperty]
        public Order order { get; set; }
        public CheckoutPageModel(IOrderRepository _orderRepository, IShoppingCart _shoppingCart)
        {
            orderRepository = _orderRepository;
            shoppingCart = _shoppingCart;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.shoppingCartItems = items;

            if (shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first.");
            }
            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage");
            }
            else
            {
                ModelState.AddModelError("", ModelState.ValidationState.ToString());
            }

            return Page();
        }
    }
}
