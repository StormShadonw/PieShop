using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {

        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        //public IActionResult Index()
        //{
        //    var pies = new PieViewModelIndex(_pieRepository.GetAllPies, "All pies");
        //    return View(pies);
        //}

        public IActionResult Index(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.GetAllPies.OrderBy(p => p.Id);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.GetAllPies.Where(p => p.Category.Name == category).OrderBy(p => p.Id);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.Name == category)?.Name;
            }
            return View(new PieViewModelIndex(pies, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieByID(id);
            if (pie == null) return NotFound();
            return View(pie);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
