using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.GetAllCategories.OrderBy(x => x.Name).ToList();
            return View(categories);
        }
    }
}
