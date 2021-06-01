using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SD_Company.Models;
using SD_Company.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeRepo _employee;

        public EmployeeController(EmployeeRepo employee)
        {
            _employee = employee;
        }


        // get all Employee for department
        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return _employee.GetAllEmployees();
        }



        // get Employee by id
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var result = _employee.GetEmployeeById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        // add Employee

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = await _employee.AddEmployee(employee);
                if (result != null)
                    return Ok(employee);
                return StatusCode(StatusCodes.Status500InternalServerError, "Try again");
            }
            return BadRequest(ModelState);
        }



        //edit Employee
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(Employee emps)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                
                var result = _employee.EditEmployeeAsync(emps);
                if (result != null)
                    return NoContent();
                return NotFound();
            }

        }


        //delete Employee
        [HttpDelete("{id}")]
        public ActionResult<Employee> deleteEmployee(int id)
        {
            var result = _employee.DeleteEmployee(id);
            if (result != null)
                return NoContent();
            return NotFound();
        }
    }
}
