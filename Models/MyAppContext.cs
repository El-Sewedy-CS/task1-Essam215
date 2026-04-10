using Microsoft.EntityFrameworkCore;

namespace Demo_2.Models
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<Category> Categories { get; set; }
    }
}
