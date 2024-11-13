using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents
{
    public class _Contact:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
