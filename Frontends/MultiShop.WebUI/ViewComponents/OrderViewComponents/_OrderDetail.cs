using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetail:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
