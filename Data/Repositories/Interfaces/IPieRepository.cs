namespace PieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies { get; }
        IEnumerable<Pie> GetPiesOfTheWeek { get; }
        Pie? GetPieByID(int id);
        List<Pie> SearchPies(string searchQuery);
    }
}
