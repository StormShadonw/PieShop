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

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

        }
    }
}
