using DotNetConnection.Data;
using DotNetConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNetConnection.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c) {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(c);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public IActionResult Edit(int id)
        {
            Category c = _db.Categories.Find(id);
            return View(c);

        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                Category categoryToEdit = _db.Categories.Find(c.CategoryId);
                categoryToEdit.Name = c.Name;
                categoryToEdit.LastUpdatedAt = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(c);
        }
    }
}
