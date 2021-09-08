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
            modelBuilder.Entity<FoodOrder>()
              .HasOne<Food>(fc => fc.Food)
              .WithMany(f => f.FoodOrders)
              .HasForeignKey(s => s.FoodId);
            modelBuilder.Entity<FoodOrder>()
                .HasOne<Order>(fc => fc.Order)
                .WithMany(f => f.FoodOrders)
                .HasForeignKey(s => s.OrderId);
            modelBuilder.Entity<Order>()
               .HasOne<User>(fc => fc.User)
               .WithMany(f => f.Orders)
               .HasForeignKey(s => s.UserId);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }

        public DbSet<Order> Orders { get; set; }
       // public DbSet<WebApplication3.ViewModels.FoodViewModel> FoodViewModels { get; set; }
        public DbSet<WebApplication3.Models.FoodCategory> FoodCategory { get; set; }
        public DbSet<WebApplication3.Models.FoodOrder> FoodOrder { get; set; }
    }
}
