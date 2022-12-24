namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private PieShopDbContext PieShopDbContext;
        public CategoryRepository(PieShopDbContext _context)
        {
            PieShopDbContext = _context;
        }
        public IEnumerable<Category> GetAllCategories => PieShopDbContext.Categories.OrderBy(category => category.Name);
    }
}
