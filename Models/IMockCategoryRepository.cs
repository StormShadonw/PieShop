namespace PieShop.Models
{
    public interface IMockCategoryRepository
    {
        public IEnumerable<Category> GetAllCategories => new List<Category>
        {
            new Category { Id = 1,
                Name = "Fruit Pies",
                Description = "All - fruit pies",
                CreatedBy = "llopez",
                CreatedDate = DateTime.Now,
            },            
            new Category { Id = 1,
                Name = "Cheese cakes",
                Description = "Cheesy all the way",
                CreatedBy = "llopez",
                CreatedDate = DateTime.Now,
            },
           new Category { Id = 1,
                Name = "Cheese cakes",
                Description = "Cheesy all the way",
                CreatedBy = "llopez",
                CreatedDate = DateTime.Now,
            },
        }
    }
}
