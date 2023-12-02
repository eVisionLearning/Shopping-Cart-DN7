using Microsoft.AspNetCore.Mvc;

namespace MyShoppingCart.Controllers
{
    public class TestController : Controller
    {
        public IActionResult AdminTheme()
        {
            return View();
        }
        public IActionResult Index()
        {
            if (DateTime.Now.Hour == 19)
            {
                TempData["Message"] = "Hello the time is currently 19";
                return RedirectToAction("Privacy", "home");
            }
            
            List<string> names = new List<string>();
            names.Add("John");
            names.Add("Alex");
            names.Add("James");
            names.Add("Bernice");
            names.Add("Mary");

            DateTime dateTime = DateTime.Now;
            
            ViewBag.Now = dateTime;
            string obj = "Western Mutual";
            ViewData["Company"] = obj;
            return View(names);


        }

        public IActionResult Details()
        {

            return View();
        }
    }
}
