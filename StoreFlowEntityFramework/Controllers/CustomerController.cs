using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Entities;

namespace StoreFlowEntityFramework.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x=>x.CustomerName + x.CustomerSurname).ToList();
            return View(values);
        }
        public IActionResult CustomerListOrderByDescBalance()
        {
            var values = _context.Customers.OrderByDescending(x=>x.CustomerBalance).ToList();
            return View(values);
        }
        public IActionResult CustomerListGetByCity(string city)
        {
            var exists = _context.Customers.Any(x=>x.CustomerCity==city);
            if (exists)
            {
                ViewBag.message = $"{city} şehrinde en az 1 tane müşteri var";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok";
            }
                return View(exists);
        }














        [HttpGet]
        public IActionResult CustomerAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerAdd(Customer customer)
        {
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomerDelete(int id)
        {
            var detectedCustomer = _context.Customers.Find(id);
            _context.Customers.Remove(detectedCustomer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public IActionResult CustomerUpdate(int id)
        {
            var detectedCustomerUpdate = _context.Customers.Find(id);
            return View(detectedCustomerUpdate);
        }
        [HttpPost]
        public IActionResult CustomerUpdate(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

    }
}
