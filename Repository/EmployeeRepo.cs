using Microsoft.EntityFrameworkCore;
using SD_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Repository
{
    public class EmployeeRepo
    {
        public EmployeeRepo(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        private CompanyContext _companyContext;
        //get Employee
        public List<Employee> GetAllEmployees()
        {
            var deptId = _companyContext.Departments.FirstOrDefault().DeptNo;
            return _companyContext.Departments.Include(a => a.Employees).FirstOrDefault(s => s.DeptNo == deptId).Employees;
        }

        // get Employee by id
        public Employee GetEmployeeById(int id)
        {
            var deptId = _companyContext.Departments.FirstOrDefault().DeptNo;
            return _companyContext.Employees.FirstOrDefault(c => c.EmpNo == id && c.DeptNo == deptId);
        }
        // add   Employee
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var deptId = _companyContext.Departments.FirstOrDefault().DeptNo;
            var proNo = _companyContext.Projects.FirstOrDefault().ProjectNo;
                if (employee != null)
                {
                    employee.DeptNo=deptId;
                    _companyContext.Employees.Add(employee);
                    _companyContext.SaveChanges();
                }
            return employee;
        }


        //  Edit Employee
        public Employee EditEmployeeAsync(Employee employee)
        {
            Employee EmployeeDetails = GetEmployeeById(employee.EmpNo);
            if (employee != null)
            {
                EmployeeDetails.Fname = employee.Fname;
                EmployeeDetails.Lname = employee.Lname;
                EmployeeDetails.Salary = employee.Salary;
                EmployeeDetails.Department.DeptName = employee.Department.DeptName;
                _companyContext.SaveChanges();
                return EmployeeDetails;
            }
            return null;
        }




        // delete Employee
        public Employee DeleteEmployee(int id)
        {
            Employee employee = GetEmployeeById(id);
            if (employee != null)
            {
                _companyContext.Remove(employee);
                _companyContext.SaveChanges();

            }
            return employee;

        }
    }
}
