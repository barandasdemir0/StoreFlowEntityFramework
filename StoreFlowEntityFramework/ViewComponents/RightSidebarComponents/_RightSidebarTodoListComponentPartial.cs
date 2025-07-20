using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarTodoListComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarTodoListComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.OrderBy(x=>x.TodoId).ToList().TakeLast(10).ToList();
            return View(values);
        }
    }
}
