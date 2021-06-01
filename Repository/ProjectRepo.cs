using Microsoft.EntityFrameworkCore;
using SD_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Repository
{
    public class ProjectRepo
    {
        public ProjectRepo(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        private CompanyContext _companyContext;
        //get Project
        public List<Project> GetAllProjects()
        {
            return _companyContext.Projects.ToList();
        }

        // get Project by id
        public Project GetProjectById(int id)
        {
            Project project = _companyContext.Projects.FirstOrDefault(s => s.ProjectNo == id);
            return project;
        }

        //add Project
        public Project addProject(Project Project)
        {
            _companyContext.Projects.Add(Project);
            _companyContext.SaveChanges();

            return Project;
        }
        //edit Project
        public Project EditProject(Project Project)
        {
            Project ProjectDetails = GetProjectById(Project.ProjectNo);
            if (Project != null)
            {
                ProjectDetails.ProjectName = Project.ProjectName;
                ProjectDetails.Budget = Project.Budget;
                _companyContext.SaveChanges();
                return ProjectDetails;
            }
            return null;

        }
        // delete Project
        public Project deleteProject(int id)
        {
            Project Project = GetProjectById(id);
            if (Project != null)
            {
                _companyContext.Remove(Project);
                _companyContext.SaveChanges();

            }
            return Project;
        }
    }
}
