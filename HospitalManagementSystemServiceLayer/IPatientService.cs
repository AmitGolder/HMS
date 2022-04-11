using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemServiceLayer
{
    interface IPatientService
    {
        Task<IList<Patient>> GetPatientList();

        Patient SearchPatient(int ptID);

        public void AddPatient(Patient pt);

    }
}
