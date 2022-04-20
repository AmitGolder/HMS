using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class HealthDepartment
    {
        internal object depName;

        [Key]
        public int DeptId { get; set; }


        [Required]
        public string DeptName { get; set; }
    }
}
