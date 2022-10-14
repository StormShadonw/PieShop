﻿namespace PieShop.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Pie>? Pies { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
