using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _SalesStatusDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
