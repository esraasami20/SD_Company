using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        [Required]
        [MinLength(3), MaxLength(10)]
        public string Fname { get; set; }
        [Required]
        [MinLength(3), MaxLength(10)]
        public string Lname { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Department")]
        public int? DeptNo { get; set; }
        public Department Department { get; set; }
        public virtual List<Works_on> Works_Ons { get; set; }
    }
}
