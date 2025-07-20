using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents.LayoutComponents
{
    public class _LayoutMessageOnNavbarComponentPartial: ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutMessageOnNavbarComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
           var values = _context.Messages.Where(y=>y.IsRead==false).OrderByDescending(x=>x.MessageId).Take(3).ToList();
            ViewBag.MessageCount = _context.Messages.Count();
            return View(values);
        }
    }
}
