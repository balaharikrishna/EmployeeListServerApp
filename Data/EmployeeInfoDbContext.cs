using EmployeeInfo.Modals;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Data

{
    public class EmployeeInfoDbContext : DbContext
    {
        public EmployeeInfoDbContext(DbContextOptions<EmployeeInfoDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
