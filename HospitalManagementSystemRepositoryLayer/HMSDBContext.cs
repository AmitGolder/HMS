using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalManagementSystemRepositoryLayer
{
    public class HMSDBContext : DbContext
    {
        public HMSDBContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Patient> Student { get; set; }
    }
}
