using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category{ get; set; }
       
        public EditModel(ApplicationDbContext db)
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
        public async Task<IActionResult> OnPost()
        {
            //custom error
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError( "Category.Name" , "The Display Order canno match the Display Name");
            }

            //Server Error
            if (ModelState.IsValid)
            {
                 _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category update Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
