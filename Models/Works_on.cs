using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SD_Company.Models
{
    public class Works_on
    {
        [Key]
        [Column(Order =1)]
        public int EmpNo { get; set; }
        [Key]
        [Column(Order = 2)]
        public int  ProjectNo { get; set; }
        [Required]
        [MinLength(2), MaxLength(10)]
        public string Job { get; set; }
        public DateTime Enter_Date { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }



    }
}
