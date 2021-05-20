using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .HasOne<FoodCategory>(fc => fc.FoodCategory)
                .WithMany(f => f.Foods)
                .HasForeignKey(s => s.FoodCategoryId);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
       // public DbSet<WebApplication3.ViewModels.FoodViewModel> FoodViewModels { get; set; }
        public DbSet<WebApplication3.Models.FoodCategory> FoodCategory { get; set; }
        public DbSet<WebApplication3.Models.FoodOrder> FoodOrder { get; set; }
    }
}
