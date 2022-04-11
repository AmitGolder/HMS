using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure
{
    public class PatientService : IPatientService
    {
        public HMSDBContext _appContext;
        public PatientService(HMSDBContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IList<Patient>> GetPatientList()
        {
            IList<Patient> pt;

            try
            {
                await Task.Delay(1000);
                pt = _appContext.Set<Patient>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return pt;
        }

        public Patient SearchPatient(int ptID)
        {

            Patient pt;

            try
            {
                pt = _appContext.Find<Patient>(ptID);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return pt;
        }


        public void AddPatient(Patient pt)
        {
            _appContext.Add<Patient>(pt);
            _appContext.SaveChanges();
        }

        public bool EditPatient(Patient rdUpdate)
        {
            var patient = SearchPatient(rdUpdate.PatientID);

            patient.PatientStatus = rdUpdate.PatientStatus;
            patient.PatientStatus = rdUpdate.PatientStatus;
            if (_appContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

}
