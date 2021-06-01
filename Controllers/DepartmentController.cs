using Microsoft.AspNetCore.Authorization;
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
    public class DepartmentController : ControllerBase
    {
        private DepartmentRepo _departmentRepo;

        public DepartmentController(DepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        [HttpGet]
        public  List<Department> GetAll()
        {
            var departs =  _departmentRepo.getAllDepartments();
            return departs;
        }
        // get Department by id
        [HttpGet("{id}")]
        public ActionResult<Department> GetStatus(int id)
        {
            var result = _departmentRepo.getDeptById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        // add Department
        [HttpPost]
        public ActionResult<Department> AddDepartment([FromBody] Department department)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Department result = _departmentRepo.addDepartment(department);

                return Ok(result);
            }

        }
        //edit Department
        [HttpPut("{id}")]
        public ActionResult EditDepartment(int id, [FromBody] Department department)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                department.DeptNo = id;
                var result = _departmentRepo.EditDepartment(department);
                if (result != null)
                    return NoContent();
                return NotFound();
            }

        }
        // delete Department
        [HttpDelete("{id}")]
        public ActionResult deleteDepartment(int id)
        {
            var result = _departmentRepo.deleteDepartment(id);
            if (result != null)
                return NoContent();
            return NotFound();
        }
    }
}
