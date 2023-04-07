
using BulkyBook.DataAccess.Repositoy.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {

            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }


        //Get
        public IActionResult Create()
        {

            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //Custom error message
            if(obj.Name ==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("customerror", "the Display Order can't match name");
            }
            if (ModelState.IsValid) {
                _db.Add(obj);
                _db.Save();
                TempData["success"]="Category created scuccessfuly";
                return RedirectToAction("Index");
            }

            return View(obj);
            
        }



        //EDIT
        public IActionResult Edit(int ? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }

            // 3 ways to find an item
             // var categoryfromDb = _db.Categories.Find(id);
            var category = _db.GetFirstOrDefault(u => u.Id == id);
           //
           //
           //var category = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null) {
                return NotFound();
            }
            return View(category);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //Custom error message
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("customerror", "the Display Order can't match name");
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Category updated scuccessfuly";
                return RedirectToAction("Index");
            }

            return View(obj);

        }




        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // 3 ways to find an item
           // var categoryfromDb = _db.Categories.Find(id);
             var categoryfromDb = _db.GetFirstOrDefault(u => u.Id == id);
            //
            //
            //var category = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        //post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            //Custom error message
            if (obj == null)
            {
                return NotFound();
            }
         
                _db.Remove(obj);
                _db.Save();
                TempData["success"] = "Category deleted scuccessfuly";
                return RedirectToAction("Index");
       
        }

    }
}
