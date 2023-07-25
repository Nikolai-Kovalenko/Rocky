using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rocky.Data;
using Rocky.Models;
using Rocky.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Rocky.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ogjList = _db.Product;

            foreach(var obj in ogjList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            }

            return View(ogjList);
        }

        // Get Upsert
        public IActionResult Upsert(int? id)
        {

            /*            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        });


                        // ViewBag.CategoryDropDown = CategoryDropDown;
                        ViewData["CategoryDropDown"] = CategoryDropDown;*/

            // Product product = new Product();

            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if(id == null) 
            { 
                // this is for create
                return View(productVM);
            }
            else
            {
                productVM.Product = _db.Product.Find(id);
                if(productVM.Product == null)
                {
                    return NotFound();
                }
                return View(productVM);
            }
        }

        // POST - Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }   
            return View(obj);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
