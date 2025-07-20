using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents.LayoutComponents
{
    public class _LayoutToDoOnNavbarComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutToDoOnNavbarComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var result = _context.Todos.Where(y=>y.Status==false).OrderByDescending(x=>x.TodoId).Take(5).ToList();
            ViewBag.todoTotalCount = _context.Todos.Count();
            return View(result);
        }
    }
}
