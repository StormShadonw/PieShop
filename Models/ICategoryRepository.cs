namespace PieShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Pie> GetAllCategories { get; }

    }
}
