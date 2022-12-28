using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        public PieShopDbContext pieShopDbContext { get; set; }
        public PieRepository(PieShopDbContext _context)
        {
            pieShopDbContext = _context;
        }
        public IEnumerable<Pie> GetAllPies => pieShopDbContext.Pies.Include(c => c.Category);

        public IEnumerable<Pie> GetPiesOfTheWeek => pieShopDbContext.Pies.Include(c => c.Category);

        public Pie? GetPieByID(int id) => pieShopDbContext.Pies.FirstOrDefault(p => p.Id == id);

        public List<Pie> SearchPies(string searchQuery)
        {
            return pieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery)).ToList();
        }
    }
}
