using Microsoft.EntityFrameworkCore;
using EmployeePayrollAPI.Models;

namespace EmployeePayrollAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}