using Microsoft.EntityFrameworkCore;

namespace ITIProject.Models
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CompanyITI;Integrated Security=True;Trust Server Certificate=true;");
        }

        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Office> Offices{ get; set; }
        public DbSet<Emp_Project> Emp_Projects { get; set; }    
    }
}
