using Microsoft.EntityFrameworkCore;

namespace OrderTrackingApp.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderCart>().HasKey(oc => new { oc.OrderId, oc.ItemId });
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderCart> OrderCart { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<User> User { get; set; }
    }
}
