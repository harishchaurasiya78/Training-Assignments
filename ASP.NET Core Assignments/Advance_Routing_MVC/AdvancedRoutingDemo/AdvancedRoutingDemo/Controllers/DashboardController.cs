using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(string role)
        {
            if (role == "admin")
                return Content("Welcome Admin - You see the Admin Dashboard");
            else
                return Content("Welcome User - You see the User Dashboard");
        }
    }
}
