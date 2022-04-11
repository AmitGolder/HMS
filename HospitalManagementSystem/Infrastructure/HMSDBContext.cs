using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Infrastructure
{
    public class HMSDBContext : DbContext
    {
        public HMSDBContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Patient> Patient { get; set; }
        DbSet<HealthDepartment> HealthDepartments { get; set; }

    }
}
