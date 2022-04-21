using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class HealthDepartmentController : Controller
    {
        private readonly IHealthDepartmentService _depService;
        private readonly ILogger<HealthDepartmentController> _Logger;
        public HealthDepartmentController(IHealthDepartmentService appContext, ILogger<HealthDepartmentController> Logger)
        {
            _Logger= Logger;
            _depService = appContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AddHealthDepartmentById()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHealthDepartmentById(HealthDepartment depName)
        {
            _Logger.LogInformation("Department endpoint starts");
            try
            {

                _depService.AddHealthDepartment(depName);

                _Logger.LogInformation("Department endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            ViewBag.Message = string.Format("Department Added Successfully");
            return View();
           
        }

        


        public ActionResult UpdateDepartment(HealthDepartment depatName)
        {
            _Logger.LogInformation("Department endpoint starts");
            bool dep;
            try
            {
                dep = _depService.UpdateDepartment(depatName);
                _Logger.LogInformation("Department endpoint completed");
                return Ok(dep);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }

        public IActionResult DeleteDepartmentBydepID(int depid)
        {
            _Logger.LogInformation("Department endpoint starts");

            try
            {

                var responseModel = _depService.DeleteHealthDepartment(depid);
                if (responseModel == null) return NotFound();
                _Logger.LogInformation("Department endpoint completed");

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }

        public ActionResult SearchHealthDepartment(int depid)
        {
            _Logger.LogInformation("Department endpoint starts");
            HealthDepartment dept;
            try
            {
                dept = _depService.SearchHealthDepartment(depid);
                _Logger.LogInformation("Department endpoint completed");
            }

            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest("Not Found");
            }
            return Ok(dept);
        }
    }
}
