namespace PieShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        float getShoppingCartTotal();
        List<ShoppingCartItem> shoppingCartItems { get; set; }
    }
}
