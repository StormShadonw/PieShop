using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository pieRepository;
        public SearchController(IPieRepository _pieRepository)
        {
            pieRepository = _pieRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var pies = pieRepository.GetAllPies;
            return Ok(pies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(!pieRepository.GetAllPies.Any(p => p.Id == id)) return NotFound();
            return Ok(pieRepository.GetAllPies.Where(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            List<Pie> pies = new List<Pie>();
            if(string.IsNullOrEmpty(searchQuery))
            {
                return NotFound();
            }
            pies = pieRepository.SearchPies(searchQuery);
            return new JsonResult(pies);
        }
    }
}
