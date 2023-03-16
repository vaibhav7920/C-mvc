using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public String EmployeeProfile(int id)
        {
            return "Profile"+id;
        }
        public String Address(int id, string department)
        {
            return "id= " + id + " dept = "+ department;
        }
    }
}
