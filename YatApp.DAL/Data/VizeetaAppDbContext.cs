using Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class VizeetaAppDbContext :DbContext
{
    public VizeetaAppDbContext(DbContextOptions<VizeetaAppDbContext> options):base(options)    
    {
        
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<City> Cities { get; set; }
  
}
