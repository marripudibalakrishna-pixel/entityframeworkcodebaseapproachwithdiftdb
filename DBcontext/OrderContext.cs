using Microsoft.EntityFrameworkCore;
using entityframeworkcodebaseapproachwithdiftdb.Entity;

namespace entityframeworkcodebaseapproachwithdiftdb.DBcontext
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options): base(options)
        {

        }
        public DbSet<orders> orders { get; set; }
    }
}
