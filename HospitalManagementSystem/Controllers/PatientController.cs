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
        private readonly SendServiceBusMessage _sendServiceBusMessage;

        public PatientController(IPatientService appContext, ILogger<PatientController> Logger, SendServiceBusMessage sendServiceBusMessage)
        {
            _Logger = Logger;
            _ptService = appContext;
            _sendServiceBusMessage = sendServiceBusMessage;

        }
        public IActionResult Index()
        {
            return View();
        }


        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient(Patient pt)
        {
            _Logger.LogInformation("Patient endpoint starts");
            try
            {
                _ptService.AddPatient(pt);
                await _sendServiceBusMessage.sendServiceBusMessage(new ServiceBusMessageData
                {
                    PatientName = pt.PatientName,
                    PatientStatus= pt.PatientStatus,
                    PatientProb = pt.PatientProb,
                    DeptName = pt.DeptId,
                    Message = "Patient Added Successfully",
                    Action = "Add"
                    
                });
                _Logger.LogInformation("Patient endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            ViewBag.Message = string.Format("Patient Added Successfully");
            return View();
        }
        

        public ActionResult EditPatient(Patient status)
        {
            _Logger.LogInformation("Patient endpoint starts");
            bool pt;
            try
            {
                pt = _ptService.EditPatient(status);
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