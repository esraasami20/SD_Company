using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Models
{
    public class Project
    {
        [Key]
        public int ProjectNo { get; set; }
        [Required]
        [MinLength(3), MaxLength(10)]
        public string ProjectName { get; set; }
        public int Budget { get; set; }
        public virtual List<Works_on> Works_Ons { get; set; }
    }
}
