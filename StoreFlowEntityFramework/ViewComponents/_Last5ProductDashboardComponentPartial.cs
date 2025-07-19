using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _Last5ProductDashboardComponentPartial:ViewComponent
    {
        public StoreContext _context;

        public _Last5ProductDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Products.OrderBy(x => x.ProductId).ToList().SkipLast(5).ToList().TakeLast(5).ToList();
            return View(values);
        }
    }
}
