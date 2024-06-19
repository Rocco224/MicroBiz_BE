using HRService.Models;
using Microsoft.EntityFrameworkCore;

namespace HRService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Absence> Absence { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
    }
}
