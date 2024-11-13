using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListGetProductCount:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
