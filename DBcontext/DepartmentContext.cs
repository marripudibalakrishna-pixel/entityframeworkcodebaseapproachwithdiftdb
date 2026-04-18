using entityframeworkcodebaseapproachwithdiftdb.Entity;
using Microsoft.EntityFrameworkCore;
namespace entityframeworkcodebaseapproachwithdiftdb.DBcontext
{
    public class DepartmentContext:DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext>options):base(options)
        {
        }
        public DbSet<Department> departments { get; set; }
    }
}
