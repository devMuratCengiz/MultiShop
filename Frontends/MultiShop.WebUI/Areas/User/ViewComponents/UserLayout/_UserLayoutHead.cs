using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
