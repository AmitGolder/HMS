using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPatientService _ptService;
        private readonly ILogger<AdminController> _Logger;
        public AdminController(IPatientService ptService, ILogger<AdminController> Logger)
        {
            _Logger = Logger;
            _ptService = ptService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllPatients()
        {
            _Logger.LogInformation("Patient endpoint starts");
            var patient = await _ptService.GetPatientList();
            try
            {
                if (patient == null) return NotFound();
                _Logger.LogInformation("patient endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return View(patient);
        }

        public ActionResult EditPatient(int Id)
        {
            var patient = _ptService.SearchPatient(Id);
            if (patient == null)
            {
                return BadRequest();
            }
            else
            {
                return View(patient);
            }
        }

        [HttpPost]
        public ActionResult EditPatient(Patient status)
        {
            _Logger.LogInformation("patient endpoint starts");
            bool pt;
            try
            {
                pt = _ptService.EditPatient(status);
                _Logger.LogInformation("patient endpoint completed");
                //return Ok(pt);
                return View(status);
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
