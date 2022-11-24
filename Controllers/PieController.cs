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
        public IActionResult Index()
        {
            var pies = new PieViewModelIndex(_pieRepository.GetAllPies, "All pies");
            return View(pies);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieByID(id);
            if (pie == null) return NotFound();
            return View(pie);
        }
    }
}
