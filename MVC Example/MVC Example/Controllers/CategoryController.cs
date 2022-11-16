using Microsoft.AspNetCore.Mvc;
using MVC_Example.Data;
using MVC_Example.Models;

namespace MVC_Example.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrden.ToString()) 
            {
                ModelState.AddModelError("name","The DisplayOrden cannot exactly match the Name.");
            }
            if (!ModelState.IsValid) { return View(obj); }

            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created succesfully";
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var CategoryFromDB = _db.Categories.Find(id);
            //var CategoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.ID == id);
            //var CategoryFromDBSingle = _db.Categories.SingleOrDefault(u => u.ID == id);

            if (CategoryFromDB == null) { return NotFound(); }

            return View(CategoryFromDB);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrden.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrden cannot exactly match the Name.");
            }
            if (!ModelState.IsValid) { return View(obj); }

            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category edited succesfully";
            return RedirectToAction("Index");
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var CategoryFromDB = _db.Categories.Find(id);
            //var CategoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.ID == id);
            //var CategoryFromDBSingle = _db.Categories.SingleOrDefault(u => u.ID == id);

            if (CategoryFromDB == null) { return NotFound(); }

            return View(CategoryFromDB);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.Categories.Find(id);
            if (obj.Name == null){ return NotFound(); }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
