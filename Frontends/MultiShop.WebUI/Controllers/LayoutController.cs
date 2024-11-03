using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
