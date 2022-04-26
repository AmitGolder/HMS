using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure
{
    public interface IPatientService
    {
        Task<IList<Patient>> GetPatientList();

        Patient SearchPatient(int ptID);

        public void AddPatient(Patient pt);
        public bool EditPatient(Patient pt);
        ResponseModel DeletePatient(int ptId);
    }
}
