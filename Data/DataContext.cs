using E_Commerce_Last_Day_.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Last_Day_.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Products).WithMany(x => x.Users);
            modelBuilder.Entity<User>().HasIndex(x => x.EmailAddress).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x=> x.Name).IsUnique();
        }
    }
}
