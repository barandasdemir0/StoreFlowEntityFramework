using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _CardStatisticsDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.totalCustomerCount = _context.Customers.Count(); //Müşteri tablosundaki veri sayısını getirecek
            ViewBag.totalCategoryCount = _context.Categories.Count();
            ViewBag.totalProductCount = _context.Products.Count();
            ViewBag.AverageBalance = _context.Customers.Average(x => x.CustomerBalance).ToString("0.00");
            ViewBag.totalOrderCount = _context.Orders.Count();
            ViewBag.sumOrderProductCount = _context.Orders.Sum(x => x.OrderCount); //sum bütün verileri aritmetik olarak toplar
            return View();

        }
    }
}
