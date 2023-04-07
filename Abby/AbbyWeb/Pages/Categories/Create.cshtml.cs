using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category{ get; set; }
        public void OnGet()
        {
        }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
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
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Category created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
