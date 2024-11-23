using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethod:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
