
using BulkyBook.DataAccess.Repositoy;
using BulkyBook.DataAccess.Repositoy.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }


        //Get
        public IActionResult Create()
        {

            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created scuccessfuly";
                return RedirectToAction("Index");
            }

            return View(obj);

        }



        //EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

          
            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type updated scuccessfuly";
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

           ;
            var coverTypefromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
           

            if (coverTypefromDb == null)
            {
                return NotFound();
            }
            return View(coverTypefromDb);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            //Custom error message
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted scuccessfuly";
            return RedirectToAction("Index");

        }

    }
}
