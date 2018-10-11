using Microsoft.EntityFrameworkCore;
 
namespace chefs_dishes.Models
{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<Chef> Chef { get; set; }
        public DbSet<Dish> Dish { get; set; }
    }
}