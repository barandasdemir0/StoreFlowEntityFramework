using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Entities;
using StoreFlowEntityFramework.ViewComponents;
using System.Security.Cryptography.X509Certificates;

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






        public async Task<IActionResult> OrderListAsync2()
        {
            var values = await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {

            var products = await _context.Products.Select(x => new SelectListItem
            {
                Value = x.ProductId.ToString(),
                Text = x.ProductName
            }).ToListAsync();
            ViewBag.product = products;


            var customer = await _context.Customers.Select(x => new SelectListItem
            {
                Value = x.CustomerId.ToString(),
                Text = x.CustomerName + " " + x.CustomerSurname
            }).ToListAsync();

            ViewBag.customer = customer;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Sipariş Alındı";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsync2");
        }


        public async Task<IActionResult> DeleteOrder(int id)
        {
            var detectedValues = await _context.Orders.FindAsync(id);
             _context.Orders.Remove(detectedValues);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsync2");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var product = await _context.Products.Select(x => new SelectListItem
            {
                Value = x.ProductId.ToString(),
                Text = x.ProductName
            }).ToListAsync();

            var customer = await _context.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.CustomerName + " " + c.CustomerSurname
            }).ToListAsync();

            ViewBag.product = product;
            ViewBag.customer = customer;

            var detectedValues = await _context.Orders.FindAsync(id);
            return View(detectedValues);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsync2");

        }






    }
}
