﻿using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Models;

namespace StoreFlowEntityFramework.ViewComponents.DashboardChartsComponents
{
    public class _DashboardOrderStatusChartComponentPartial: ViewComponent
    {
        private readonly StoreContext _context;

        public _DashboardOrderStatusChartComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var result = _context.Orders
                .GroupBy(o => o.Status)
                .Select(g => new OrderStatusChartViewModel
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return View(result);
        }
    }
}
