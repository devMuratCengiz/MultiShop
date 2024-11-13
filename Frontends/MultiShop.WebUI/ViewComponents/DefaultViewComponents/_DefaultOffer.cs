using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultOffer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
