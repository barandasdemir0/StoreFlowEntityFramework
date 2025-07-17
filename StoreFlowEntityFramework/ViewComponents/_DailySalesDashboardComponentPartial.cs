using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _DailySalesDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
