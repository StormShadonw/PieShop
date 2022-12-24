using PieShop.Models;
using PieShop.Repositories.Interfaces;

namespace PieShop.Data.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {

        private readonly PieShopDbContext context;

        private readonly IShoppingCart shoppingCart;

        public OrderRepository(PieShopDbContext _context, IShoppingCart _shoppingCart)
        {
            context = _context;
            shoppingCart = _shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.CreatedDate = DateTime.Now;
            order.Date = DateTime.Now;
            order.CreatedBy = Environment.UserName;
            List<ShoppingCartItem> shoppingCartItems = shoppingCart.shoppingCartItems;
            order.OrderDetails = new List<OrderDetail>();
            order.Total = shoppingCart.getShoppingCartTotal();

            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = shoppingCartItem.Quantity,
                    PieId = shoppingCartItem.Pie.Id,
                    UnitPrice = shoppingCartItem.Pie.Price,
                    CreatedBy = Environment.UserName,
                    CreatedDate = DateTime.Now
                };

                order.OrderDetails.Add(orderDetail);
            }

            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
