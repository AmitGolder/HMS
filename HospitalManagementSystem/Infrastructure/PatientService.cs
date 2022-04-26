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
            catch(Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }


            return pt;
        }
        public ResponseModel DeletePatient(int ptid)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var pt = SearchPatient(ptid);
                _appContext.Remove<Patient>(pt);

                _appContext.SaveChanges();
                model.ISuccess = true;
                model.Message = " Patient's record removed succesfully";
            }

            catch (Exception ex)
            {
                model.ISuccess = false;
                model.Message = " Error:" + ex.Message;
            }
            return model;
        }

        public void AddPatient(Patient pt)
        {
            _appContext.Add<Patient>(pt);
            _appContext.SaveChanges();
        }

        public bool EditPatient(Patient pt)
        {
            var patient = SearchPatient(pt.PatientID);


            if (patient != null)
            {
                patient.PatientStatus = pt.PatientStatus;
                _appContext.Update<Patient>(patient);
            }
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
