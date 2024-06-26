using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class CategoryController(CategoryDbContext db) : Controller
    {
        public readonly CategoryDbContext _db = db;

        public IActionResult Read()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? item = _db.Categories.FirstOrDefault(e => e.CategoryId == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category? item = _db.Categories.FirstOrDefault(e=>e.CategoryId == id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.FirstOrDefault(e => e.CategoryId == id);
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }


        public IActionResult Search(string? Search)
        {
            Category? obj = _db.Categories.FirstOrDefault(x => x.CategoryId == Convert.ToInt32(Search));
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

    }
}
