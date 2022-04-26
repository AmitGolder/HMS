using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure
{
    public interface IHealthDepartmentService
    {
        Task<IList<HealthDepartment>> GetHealthDepartmentList();

        void AddHealthDepartment(HealthDepartment departmentName);

        HealthDepartment SearchHealthDepartment(int departmentID);

        bool UpdateDepartment(HealthDepartment departmentName);

        public bool EditHealthDepartment(HealthDepartment departmentName);

        ResponseModel DeleteHealthDepartment(int departmentID);
        
    }
}
