using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository _pieRepository)
        {
            pieRepository = _pieRepository;
        }
        public IActionResult Index()
        {

            return View(pieRepository.GetPiesOfTheWeek);
        }
    }
}
