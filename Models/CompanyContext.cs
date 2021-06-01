using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Models
{
    public class CompanyContext :DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Works_on> Works_Ons { get; set; }
        public virtual DbSet<Department> Departments { get; set; }


        public CompanyContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Works_on>().HasKey(sc => new { sc.EmpNo, sc.ProjectNo });
        }
    }
}
