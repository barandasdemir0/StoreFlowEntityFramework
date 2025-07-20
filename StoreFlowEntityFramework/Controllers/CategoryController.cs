using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Entities;

namespace StoreFlowEntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreContext _context;

        public CategoryController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            category.CategoryStatus = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryDelete(int id)
        {
            var detectedCategory = _context.Categories.Find(id);
            _context.Categories.Remove(detectedCategory);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var detectedCategoryUpdate = _context.Categories.Find(id);
            return View(detectedCategoryUpdate);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult ReverseCategory()
        {
            var category = _context.Categories.First();
            ViewBag.c = category.CategoryName;

            var categoryValues2 = _context.Categories.SingleOrDefault(x => x.CategoryName == "Anne ve Bebek Ürünleri");
            ViewBag.v = categoryValues2.CategoryStatus + " " + categoryValues2.CategoryId.ToString();
            var values = _context.Categories.OrderBy(x=>x.CategoryId).Reverse().ToList();
            return View(values);
        }


    }
}
