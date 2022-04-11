using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        public string PatientName { get; set; }
        public string PatientStatus { get; set; }
        public string PatientProb { get; set; }
    }
}
