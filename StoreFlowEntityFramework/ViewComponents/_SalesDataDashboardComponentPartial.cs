using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _SalesDataDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _SalesDataDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Orders.OrderByDescending(z=>z.OrderId).Include(x=>x.Customer).Include(y=>y.Product).Take(5).ToList(); // Son 5 siparişi alıyoruz, siparişleri müşteri ve ürün bilgileriyle birlikte getiriyoruz ve siparişleri OrderId'ye göre azalan şekilde sıralıyoruz.
            return View(values);
        }
    }
}
