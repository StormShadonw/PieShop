using Microsoft.AspNetCore.Mvc;

namespace PieShop.Models
{
    public class ShoppingCartViewModel
    {

        public IShoppingCart ShoppingCart { get; set; }
        public float ShoppingCartTotal { get; set; }
        public int ShoppingCartTotalQuantity { get; set; }
        public ShoppingCartViewModel(IShoppingCart shoppingCart, float shoppinCartTotal, int totalQuantity)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppinCartTotal;
            ShoppingCartTotalQuantity = totalQuantity;
        }
    }
}
