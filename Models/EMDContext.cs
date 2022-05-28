using Microsoft.EntityFrameworkCore;

namespace Employee_Managment_Demo.Models
{
    public class EMDContext : DbContext
    {
        public EMDContext(DbContextOptions<EMDContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employee {get; set; }
    }
}