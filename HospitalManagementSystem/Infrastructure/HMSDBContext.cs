using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure
{
    public class HMSDBContext : DbContext
    {
        public HMSDBContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Patient> Student { get; set; }
    }
}
