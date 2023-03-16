using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
