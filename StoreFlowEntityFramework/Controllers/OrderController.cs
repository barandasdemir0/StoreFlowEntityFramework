using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.ViewComponents;

namespace StoreFlowEntityFramework.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult AllStockSmallerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);
            if (orderStockCount)
            {
                ViewBag.v = "Tüm Siparişler 5 adetten küçüktür";
            }
            else
            {
                ViewBag.v = "Tüm Siparişler 5 den küçük değildir";
            }
            return View();
        }


        public IActionResult OrdersListByStatus(string status)
        {

            var detectedvalues = _context.Orders.ToList();

            var values = _context.Orders.Where(x => x.Status.Contains(status)).ToList();
            if (!values.Any())
            {
                ViewBag.v = "hiç bir veri yok";
            }
            else
            {
                return View(values);
            }

            return View(detectedvalues);


        }





        public IActionResult OrderListSearch(string name, string filterType)
        {

            if (filterType == "start")
            {
                var values = _context.Orders.Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if (filterType == "end")
            {
                var values = _context.Orders.Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }
            var values2 = _context.Orders.ToList();
            return View(values2);
        }




    }
}
