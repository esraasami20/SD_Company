using Microsoft.EntityFrameworkCore;
using SD_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Repository
{
    public class DepartmentRepo
    {
        public DepartmentRepo(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        private CompanyContext _companyContext;
        //get department
        public List<Department> getAllDepartments()
        {
           var depts =  _companyContext.Departments.ToList();
            return depts;
        }
        //get department by id
        public Department getDeptById(int id)
        {
            Department department = _companyContext.Departments.Include(a=>a.Employees).FirstOrDefault(s => s.DeptNo ==id);
            return department;
        }

        //add dept
        public Department addDepartment(Department department)
        {
            _companyContext.Departments.Add(department);
            _companyContext.SaveChanges();

            return department;
        }
        //edit department
        public Department EditDepartment(Department department)
        {
            Department departmentDetails = getDeptById(department.DeptNo);
            if (department != null)
            {
                departmentDetails.DeptName = department.DeptName;
                departmentDetails.Location = department.Location;
                _companyContext.SaveChanges();
                return departmentDetails;
            }
            return null;

        }
        // delete department
        public Department deleteDepartment(int id)
        {
            Department department = getDeptById(id);
            if (department != null)
            {
                _companyContext.Remove(department);
                _companyContext.SaveChanges();

            }
            return department;
        }
    }
}
