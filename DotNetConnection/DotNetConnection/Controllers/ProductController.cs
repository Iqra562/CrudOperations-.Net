using DotNetConnection.Data;
using DotNetConnection.Models;
using DotNetConnection.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetConnection.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _host;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
        }
        public IActionResult Index()
        {
            return View(_db.Products.Include(e => e.Category));
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductRegisterRequest request)
        {
            ViewBag.Categories = _db.Categories;
            if (ModelState.IsValid)
            {
                string path = Path.Combine(_host.WebRootPath, "Images", request.Image.FileName);
                using (FileStream fs = new FileStream(path,FileMode.Create))
                {

                    request.Image.CopyTo(fs);
                }
                Product p = new Product();
                p.Name = request.Name;
                p.Price = request.Price;
                p.CategoryId = request.CategoryId;
                p.Image = "images/"+request.Image.FileName;
                _db.Products.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(request);


        }
    }
}
