using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [ForeignKey("HealthDepartment")]
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        [Required]
        public string PatientName { get; set; }
        public string PatientStatus { get; set; }
        public string PatientProb { get; set; }
    }
}
