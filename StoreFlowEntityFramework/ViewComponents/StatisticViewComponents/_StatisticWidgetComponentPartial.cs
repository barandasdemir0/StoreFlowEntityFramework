using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;

namespace StoreFlowEntityFramework.ViewComponents.StatisticViewComponents
{
    public class _StatisticWidgetComponentPartial:ViewComponent
    {

        private readonly StoreContext _context;

        public _StatisticWidgetComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CategoriesCount = _context.Categories.Count();
            ViewBag.ProductsMaxPrice = _context.Products.Max(x => x.ProductPrice);
            ViewBag.ProductsMinPrice = _context.Products.Min(x => x.ProductPrice);

            var ProductMaxName = _context.Products.Max(x => x.ProductPrice);
            ViewBag.ProductMaxName = _context.Products.Where(x => x.ProductPrice == ProductMaxName).Select(y => y.ProductName).FirstOrDefault();

            var ProductMinPrice = _context.Products.Min(x => x.ProductPrice);
            ViewBag.ProductMinPrice = _context.Products.Where(x => x.ProductPrice == ProductMinPrice).Select(y => y.ProductName).FirstOrDefault();


            ViewBag.totalProductSumCount = _context.Products.Sum(x => x.ProductStock);
            ViewBag.averageProductStock = _context.Products.Average(x => x.ProductStock);
            ViewBag.averageProductPrice = _context.Products.Average(x => x.ProductPrice).ToString("0.00");

            ViewBag.biggerPrice1000Product = _context.Products.Where(x => x.ProductPrice > 1000).Count();
            ViewBag.getIDIs4ProductName = _context.Products.Where(x => x.ProductId == 4).Select(y=>y.ProductName).FirstOrDefault();
            ViewBag.stockCountBigger5AndSmaller100ProductCount = _context.Products.Where(x => x.ProductPrice > 50 && x.ProductPrice < 100).Count();



            return View();
        }
    }
}
