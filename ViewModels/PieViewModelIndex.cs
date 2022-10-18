using PieShop.Models;

namespace PieShop.ViewModels
{
    public class PieViewModelIndex
    {
        public IEnumerable<Pie> pies;
        public string currentCategory;

        public PieViewModelIndex(IEnumerable<Pie> _pies, string _currentCategory)
        {
            pies = _pies;
            currentCategory = _currentCategory;
        }
    }
}
