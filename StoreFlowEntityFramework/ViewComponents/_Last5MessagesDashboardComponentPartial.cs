using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _Last5MessagesDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _Last5MessagesDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.OrderBy(x => x.MessageId).ToList().TakeLast(5).ToList();
            return View(values);
        }
    }
}
