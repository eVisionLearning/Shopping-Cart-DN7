using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShoppingCart.Data;
using MyShoppingCart.Handlers;
using MyShoppingCart.Models;

namespace MyShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _db;
        private string applicationRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private string uploadPath = Path.Combine("imgs", "categories");
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Categories.OrderBy(m => m.Rank).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                model.LogoUrl = model.Logo.SaveUploadedFile("imgs", "categories");
                
                _db.Add(model);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _db.Categories.FindAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                string existingLogoUrl = existingLogoUrl = _db.Categories.Where(m => m.Id == model.Id).Select(m => m.LogoUrl).FirstOrDefault(); ;
                model.LogoUrl = model.Logo.SaveUploadedFile("imgs", "categories");

                _db.Update(model);
                if (string.IsNullOrEmpty(model.LogoUrl))
                {
                    _db.Entry(model).Property(m => m.LogoUrl).IsModified = false;
                }
                _db.SaveChanges();

                if (!string.IsNullOrEmpty(existingLogoUrl))
                {
                    string fileToDelete = Path.Combine(applicationRootPath, existingLogoUrl.TrimStart('/')).Replace("\\", "/");
                    System.IO.File.Delete(fileToDelete);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _db.Categories.FindAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var model = await _db.Categories.FindAsync(id);
            if (model == null) return NotFound();

            //_db.Categories.Remove(model);
            _db.Remove(model);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Index");
        }
    }
}
