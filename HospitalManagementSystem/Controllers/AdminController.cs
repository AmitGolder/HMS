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
        private readonly IHealthDepartmentService _healthDeptService;
        public AdminController(IPatientService ptService, IHealthDepartmentService healthDeptService, ILogger<AdminController> Logger)
        {
            _Logger = Logger;
            _ptService = ptService;
            _healthDeptService = healthDeptService;
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

       

        public async Task<IActionResult> GetAllHealthDepartment()
        {
            _Logger.LogInformation("department endpoint starts");
            var department = await _healthDeptService.GetHealthDepartmentList();
            try
            {

                if (department == null) return NotFound();

                _Logger.LogInformation("Department endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return View(department);
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

        public ActionResult EditHealthDepartment(int Id)
        {
            var healthdepartment = _healthDeptService.SearchHealthDepartment(Id);
            if (healthdepartment == null)
            {
                return BadRequest();
            }
            else
            {
                return View(healthdepartment);
            }
        }

        [HttpPost]
        public ActionResult EditHealthDepartment(HealthDepartment depName)
        {
            _Logger.LogInformation("patient endpoint starts");
            bool hd;
            try
            {
                hd = _healthDeptService.EditHealthDepartment(depName);
                _Logger.LogInformation("patient endpoint completed");
                //return Ok(pt);
                return View(depName);
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
