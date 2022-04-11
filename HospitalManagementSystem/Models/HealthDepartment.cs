using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class HealthDepartment
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
