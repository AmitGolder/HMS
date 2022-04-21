using HospitalManagementSystem.Infrastructure;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure
{

    public class HealthDepartmentService : IHealthDepartmentService
    {
        public HMSDBContext _appContext;
        public HealthDepartmentService(HMSDBContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IList<HealthDepartment>> GetHealthDepartmentList()
        {
            IList<HealthDepartment> depatName;

            try
            {
                await Task.Delay(1000);
                depatName = _appContext.Set<HealthDepartment>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return depatName;
        }


        public void AddHealthDepartment(HealthDepartment depName)
        {
            _appContext.Add<HealthDepartment>(depName);
            _appContext.SaveChanges();
        }

        public bool UpdateDepartment(HealthDepartment dep)
        {
            var department = SearchHealthDepartment(dep.DeptId);

            if (department != null)
            {
                department.depName = dep.depName;
                _appContext.Update<HealthDepartment>(dep);
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


        public HealthDepartment SearchHealthDepartment(int depid)
        {
            HealthDepartment depat;

            try
            {
                depat = _appContext.Find<HealthDepartment>(depid);

            }
            catch (Exception)
            {
                throw;
            }
            return depat;
        }


        public ResponseModel DeleteHealthDepartment(int depid)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var depat = SearchHealthDepartment(depid);
                _appContext.Remove<HealthDepartment>(depat);

                _appContext.SaveChanges();
                model.ISuccess = true;
                model.Message = " depatent marks records removed succesfully";
            }

            catch (Exception ex)
            {
                model.ISuccess = false;
                model.Message = " Error:" + ex.Message;
            }
            return model;
        }

        public bool EditHealthDepartment(HealthDepartment hd)
        {
            var healthDepart = SearchHealthDepartment(hd.DeptId);


            if (healthDepart != null)
            {
                healthDepart.DeptName = hd.DeptName;
                _appContext.Update<HealthDepartment>(healthDepart);
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
