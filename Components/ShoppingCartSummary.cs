using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private IShoppingCart shoppingCart;

        public ShoppingCartSummary(IShoppingCart _shoppingCart)
        {
            shoppingCart = _shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.shoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart, shoppingCart.getShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
    }
}
