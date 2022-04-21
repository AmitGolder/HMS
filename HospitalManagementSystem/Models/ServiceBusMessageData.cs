using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class ServiceBusMessageData
    {
        
        
            public int? PatientID { get; set; }
            public string PatientName { get; set; }
            public string PatientStatus { get; set; }
            public string PatientProb { get; set; }
            public int DeptName { get; set; }
            public string  Message { get; set; }
            public string Action { get; set; }





    }
}
