using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShoppingCart.Data;
using MyShoppingCart.Models;

namespace MyShoppingCart.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _db;

        public AccountsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AppUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    City = model.City,
                    Country = model.Country,
                    Email = model.Email,
                    StreetAddress = model.StreetAddress,
                    Username = model.Username,
                };

                _db.Users.Add(user);
                _db.SaveChanges();

                var hasher = new PasswordHasher<string>();
                user.HashPassword = hasher.HashPassword(user.Id.ToString(), model.Password);

                _db.SaveChanges();

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
