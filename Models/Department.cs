using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Models
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }
        [Required]
        [MaxLength(20),MinLength(2)]
        public string DeptName { get; set; }
        [Required]
        [MaxLength(30), MinLength(2)]
        public string Location { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
