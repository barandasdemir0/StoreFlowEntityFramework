using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.ViewComponents.LayoutComponents
{
    public class _LayoutScriptsComponentPartial:ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
