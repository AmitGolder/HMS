using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using System;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _ptService;
        private readonly ILogger<PatientController> _Logger;

        public PatientController(IPatientService appContext, ILogger<PatientController> Logger)
        {
            _Logger = Logger;
            _ptService = appContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPatietById(int ptID)
        {
            _Logger.LogInformation("Patient endpoint starts");
            Patient pt;
            try
            {
                pt = _ptService.SearchPatient(ptID);

                _Logger.LogInformation("Patient endpoint completed");
            }

            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest("Not Found");
            }
            return Ok(pt);
        }

        public ActionResult AddPatientById()
        {
            return View();
        }
        public ActionResult AddPatientById(Patient pt)
        {
            _Logger.LogInformation("Patient endpoint starts");
            try
            {
                _ptService.AddPatient(pt);
                _Logger.LogInformation("Patient endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            return Ok("Patient Added");
        }

        public ActionResult EditStudent(Patient course)
        {
            _Logger.LogInformation("Patient endpoint starts");
            bool pt;
            try
            {
                pt = _ptService.EditPatient(course);
                _Logger.LogInformation("Patient endpoint completed");
                return Ok(pt);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }
    }
}