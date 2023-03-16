using CRUDapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        // READ
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeDetails(int id)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/employees.json");
            string json = System.IO.File.ReadAllText(filePath);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            Employee employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }


        //WRITE
        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/employees.json");
            string json = System.IO.File.ReadAllText(filePath);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            int newId = employees.Max(e => e.Id) + 1;
            employee.Id = newId;
            employees.Add(employee);

            string updatedJason = JsonConvert.SerializeObject(employees);

            System.IO.File.WriteAllText(filePath, updatedJason);
            return employee;
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id,[FromBody] Employee employee)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/employees.json");
            string json = System.IO.File.ReadAllText(filePath);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            Employee existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if(existingEmployee == null) {
                return NotFound();

            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Designation = employee.Designation;

            string updatedJason = JsonConvert.SerializeObject(employees);
            System.IO.File.WriteAllText(filePath, updatedJason);

            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/employees.json");
            string json = System.IO.File.ReadAllText(filePath);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            var employee = employees.FirstOrDefault(e=>e.Id == id);

            if(employee == null) { return NotFound(); }
            employees.Remove(employee);

            string updatedJason = JsonConvert.SerializeObject(employees);
            System.IO.File.WriteAllText(filePath, updatedJason);

            return NoContent();
        }

    }
}
