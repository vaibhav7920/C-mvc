using Employeedatabase.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employees;

        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            var employeefromDb = _context.Employees.Find(id);
            if (employeefromDb != null)
            {
                employeefromDb.Salary = employee.Salary;
                employeefromDb.Name = employee.Name;
                employeefromDb.Department = employee.Department;
            }
            else
            {
                employeefromDb.Id = employee.Id;
                employeefromDb.Salary = employee.Salary;
                employeefromDb.Name = employee.Name;
                employeefromDb.Department = employee.Department;
            }

            _context.Employees.Update(employeefromDb);
            _context.SaveChanges();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeefromDb = _context.Employees.Find(id);
            _context.Employees.Remove(employeefromDb);
            _context.SaveChanges();
        }


        [HttpGet("{id},{department}")]
        public Employee GetDep(int id, string department)
        {
            var data = _context.Employees;
            var finaldata = from d in data
                            where d.Department == department
                            select new
                            {
                                ID = d.Id,
                                NAME = d.Name,
                                Dep = d.Department
                            };
            Employee employee = (Employee)finaldata;
            return employee;

        }
    }
}
