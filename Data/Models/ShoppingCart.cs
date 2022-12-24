using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly PieShopDbContext context;

        public ShoppingCart(PieShopDbContext _context)
        {
            context = _context;
        }
        public string Id { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; } = default;

        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            PieShopDbContext context = service.GetService<PieShopDbContext>() ?? throw new Exception("Error Initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(context);
        }

        public void AddToCart(Pie pie)
        {
            var user = Environment.UserName;
            var shoppingCartItem = context.shoppingCartItems.SingleOrDefault(shoppingCartItem => shoppingCartItem.Pie.Id == pie.Id && shoppingCartItem.ShoppingCartId == Id);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = Id,
                    Pie = pie,
                    Quantity = 1,
                    CreatedBy = user,
                    CreatedDate = DateTime.Now,
                    Active = true
                };
                context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            context.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = context.shoppingCartItems.Where(x => x.ShoppingCartId == Id);
            context.shoppingCartItems.RemoveRange(cartItems);
            context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ??= context.shoppingCartItems.Where(x => x.ShoppingCartId == Id).Include(x => x.Pie).ToList();
        }

        public float getShoppingCartTotal()
        {
            return (float)context.shoppingCartItems.Where(x => x.ShoppingCartId == Id).Select(x => x.Pie.Price * x.Quantity).Sum();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = context.shoppingCartItems.SingleOrDefault(shoppingCartItem => shoppingCartItem.Pie.Id == pie.Id && shoppingCartItem.ShoppingCartId == Id);
            var localQuantity = 0;
            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    context.shoppingCartItems.Remove(shoppingCartItem);
                }
            }
            context.SaveChanges();
            return localQuantity;
        }
    }
}
