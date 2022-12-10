namespace PieShop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Pie Pie { get; set; }
        public int Quantity { get; set; }
        public string? ShoppingCartId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}
