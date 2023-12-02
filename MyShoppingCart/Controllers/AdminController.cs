using Microsoft.AspNetCore.Mvc;

namespace MyShoppingCart.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
