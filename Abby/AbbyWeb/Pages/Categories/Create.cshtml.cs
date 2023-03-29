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
await _db.Category.AddAsync(Category);
           await _db.SaveChangesAsync();  
            return RedirectToPage("Index");
        }
    }
}
