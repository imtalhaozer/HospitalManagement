using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Contexts;

public class MsSqlContext : DbContext
{
    public MsSqlContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1453; Database=HospitalManagement; " +
                                    "User=sa; Password=admin123456789; TrustServerCertificate=true");
    }
    
    DbSet<Doctor> Doctors { get; set; }
    DbSet<Patient> Patients { get; set; }
    DbSet<Appoinment> Appoinments { get; set; }
}