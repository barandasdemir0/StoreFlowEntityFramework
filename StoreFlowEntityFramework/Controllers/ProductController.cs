using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Entities;

namespace StoreFlowEntityFramework.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
    
            var productList = _context.Products.Include(x=>x.Category).ToList(); //include metodu ile birleştirme oluyor yani category nesnesinden categorye erişebiliyoruz artık liste sayfamızdan categorydeki category name ulabileceğiz
            return View(productList);
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {

            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            ViewBag.categoryList = categories;


            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult ProductDelete(int id)
        {
            var detectedDeleteProduct = _context.Products.Find(id);
            _context.Products.Remove(detectedDeleteProduct);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            var detectedUpdateProduct = _context.Products.Find(id);

            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            ViewBag.categoryList = categories;



            return View(detectedUpdateProduct);
        }

        [HttpPost]
        public IActionResult ProductUpdate(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
             return RedirectToAction("ProductList");

        }


        public IActionResult First5ProductList()
        {
            var values = _context.Products.Include(x=>x.Category).Take(5).ToList();
            return View(values);
        }
        public IActionResult Last4ProductList()
        {
            var values = _context.Products.Include(x=>x.Category).Skip(4).Take(10).ToList();
            return View(values);
        }


       


    }
}
