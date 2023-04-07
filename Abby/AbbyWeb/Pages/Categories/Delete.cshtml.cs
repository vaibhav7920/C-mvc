using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category{ get; set; }
       
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Ways to retrive data
            //Category = _db.Category.First(u => u.Id == id);
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);
            //Category = _db.Category.Single(u => u.Id == id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id); ->returns multiple records
        }
        public async Task<IActionResult> OnPost( )
        {
            
            
                var categoryFromDb = _db.Category.Find(Category.Id);
                if (categoryFromDb != null)
                {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
