﻿using Microsoft.AspNetCore.Mvc;

namespace StoreFlowEntityFramework.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }
    }
}
