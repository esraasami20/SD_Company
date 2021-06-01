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
    public class ProjectController : ControllerBase
    {

        private ProjectRepo _projectRepo;

        public ProjectController(ProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }
        [HttpGet]
        public List<Project> GetAll()
        {
            var departs = _projectRepo.GetAllProjects();
            return departs;
        }
        // get Project by id
        [HttpGet("{id}")]
        public ActionResult<Project> GetProjects(int id)
        {
            var result = _projectRepo.GetProjectById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        // add Project
        [HttpPost]
        public ActionResult<Project> AddProject([FromBody] Project Project)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Project result = _projectRepo.addProject(Project);

                return Ok(result);
            }

        }
        //edit Project
        [HttpPut("{id}")]
        public ActionResult EditProject(int id, [FromBody] Project Project)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Project.ProjectNo = id;
                var result = _projectRepo.EditProject(Project);
                if (result != null)
                    return NoContent();
                return NotFound();
            }

        }
        // delete Project
        [HttpDelete("{id}")]
        public ActionResult deleteProject(int id)
        {
            var result = _projectRepo.deleteProject(id);
            if (result != null)
                return NoContent();
            return NotFound();
        }
    }
}
