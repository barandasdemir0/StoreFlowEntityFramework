using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _ChartDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
