using ApiMFAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMFAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [Route("Employees")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { EmployeeID = 1, Age = 37, Designation = "Developer", Name = "André Luz" });
            empList.Add(new Employee { EmployeeID = 2, Age = 23, Designation = "Analyst", Name = "Ana" });
            empList.Add(new Employee { EmployeeID = 3, Age = 51, Designation = "Manager", Name = "Marcos" });
            empList.Add(new Employee { EmployeeID = 4, Age = 55, Designation = "Director", Name = "João" });

            return Ok(empList);
        }
    }
}
