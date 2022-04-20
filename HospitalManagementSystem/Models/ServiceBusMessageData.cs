using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class ServiceBusMessageData
    {
        
        
            public int? PatientID { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string Problem { get; set; }
            public int Department { get; set; }

    }
}
