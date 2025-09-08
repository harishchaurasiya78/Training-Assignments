﻿using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingDemo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Details(string category, int id)
        {
            return Content($"Category: {category}, Product ID: {id}");
        }

        public IActionResult ByGuid(Guid id)
        {
            return Content($"Product with GUID: {id}");
        }
    }
}
