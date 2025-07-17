using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _SidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
