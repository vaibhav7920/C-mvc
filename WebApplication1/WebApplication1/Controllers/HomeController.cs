using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello world";
        }

        public string Name()
        {
            return "My name is Vaibhav";
        }
    }
}

