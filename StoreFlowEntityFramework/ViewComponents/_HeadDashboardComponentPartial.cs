using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _HeadDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
