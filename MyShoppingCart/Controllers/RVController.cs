using Microsoft.AspNetCore.Mvc;
using MyShoppingCart.Data;

namespace MyShoppingCart.Controllers
{
    public class RVController : Controller
    {
        private readonly AppDbContext _db;

        public RVController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckUniqueEmail(string email)
        {
            var result = _db.Users.Any(u => u.Email == email);

            return Json(!result);
        }
        public IActionResult CheckUniqueUserName(string userName)
        {
            var result = _db.Users.Any(u => u.Username == userName);

            return Json(!result);
        }
    }
}
