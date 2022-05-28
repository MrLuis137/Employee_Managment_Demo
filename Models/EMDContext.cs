using Microsoft.EntityFrameworkCore;
using Employee_Managment_Demo.Models;

namespace Employee_Managment_Demo.Models
{
    public class EMDContext : DbContext
    {
        public EMDContext(DbContextOptions<EMDContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employee {get; set; }
        public DbSet<Position> Position {get; set; }
    }
}