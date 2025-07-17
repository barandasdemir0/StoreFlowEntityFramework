using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _TodoDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _TodoDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values  = _context.Todos.OrderByDescending(x=>x.TodoId).Take(6).ToList();
            return View(values);
        }
    }
}
