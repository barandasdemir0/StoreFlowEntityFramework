using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
