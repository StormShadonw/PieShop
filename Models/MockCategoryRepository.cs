namespace PieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories =>
            new List<Category>
            {
                new Category{Id=1, Name="Fruit pies", Description="All-fruity pies", CreatedBy = "llopez", CreatedDate = DateTime.Now},
                new Category{Id=2, Name="Cheese cakes", Description="Cheesy all the way", CreatedBy = "llopez", CreatedDate = DateTime.Now},
                new Category{Id=3, Name="Seasonal pies", Description="Get in the mood for a seasonal pie", CreatedBy = "llopez", CreatedDate = DateTime.Now},
            };
    }

}
