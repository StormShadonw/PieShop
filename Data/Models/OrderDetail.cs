namespace PieShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public Pie Pie { get; set; } = default!;
        public Order Order { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
