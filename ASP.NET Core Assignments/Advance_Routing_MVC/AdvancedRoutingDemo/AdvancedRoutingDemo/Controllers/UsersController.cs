using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingDemo.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Orders(string username)
        {
            return Content($"Showing orders for user: {username}");
        }
    }
}
