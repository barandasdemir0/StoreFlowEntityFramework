using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Entities;
using StoreFlowEntityFramework.Models;

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
            var values = _context.Customers.OrderBy(x => x.CustomerName + x.CustomerSurname).ToList();
            return View(values);
        }
        public IActionResult CustomerListOrderByDescBalance()
        {
            var values = _context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(values);
        }
        public IActionResult CustomerListGetByCity(string city)
        {
            var exists = _context.Customers.Any(x => x.CustomerCity == city);
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


        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers.ToList().GroupBy(c => c.CustomerCity).ToList();
            return View(groupedCustomers);
        }

        public IActionResult CustomerBycityCount()
        {
            var query = from c in _context.Customers
                        group c by c.CustomerCity into cityGroup
                        select new CustomerCityGroup
                        {

                            City = cityGroup.Key,
                            CustomerCount = cityGroup.Count()

                        };
            var model = query.OrderByDescending(x=>x.CustomerCount).ToList();
            return View(model);
        }

        public IActionResult CustomerCityList()
        {
            var values = _context.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }


        public IActionResult ParallelCustomer()
        {
            var values = _context.Customers.ToList();
            var result = values.AsParallel().Where(x => x.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
            return View(result);
        }

        public IActionResult CustomerListExceptCityIstanbul()
        {
            var allCustomers = _context.Customers.ToList();
            var customerListIstanbul = _context.Customers.Where(x => x.CustomerCity == "İstanbul").Select(y=>y.CustomerCity).ToList();
            var result = _context.Customers.ToList().ExceptBy(customerListIstanbul,x=>x.CustomerCity).ToList();
            
            return View(result);
        }



    }
}
