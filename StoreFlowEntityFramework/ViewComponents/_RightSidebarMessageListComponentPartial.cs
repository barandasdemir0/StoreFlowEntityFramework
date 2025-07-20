using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _RightSidebarMessageListComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarMessageListComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.Where(x => x.IsRead == false)/*.ToList().TakeLast(10)*/.ToList();
            return View(values);
        }
    }
}
