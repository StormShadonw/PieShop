using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class ShoppingCartController : Controller
    {

        public IShoppingCart _shoppingCart { get; set; }
        public IPieRepository _pieRepository { get; set; }

        public ShoppingCartController(IShoppingCart shoppingCart, IPieRepository pieRepository)
        {
            _shoppingCart = shoppingCart;
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.getShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.GetAllPies.FirstOrDefault(p => p.Id == pieId);
            if(selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.GetAllPies.FirstOrDefault(p => p.Id == pieId);
            if(selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
