using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPagination:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
