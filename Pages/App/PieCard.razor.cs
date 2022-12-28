using PieShop.Models;
using Microsoft.AspNetCore.Components;

namespace PieShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
