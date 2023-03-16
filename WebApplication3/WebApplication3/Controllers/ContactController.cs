using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public string[] Get()
        {
            return new string[]
            {
        "Hello",
        "World"
            };
        }
    }
}
