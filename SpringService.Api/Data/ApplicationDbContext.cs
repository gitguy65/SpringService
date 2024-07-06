using Microsoft.EntityFrameworkCore;
using SpringService.Api.Models; 

namespace SpringService.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Cateogries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                 .HasOne(q => q.UserId)
                 .WithMany(f => f.Reviews)
                 .HasForeignKey(q => q.UserId);

            modelBuilder.Entity<Booking>()
                 .HasOne(q => q.UserId)
                 .WithMany(f => f.Bookings)
                 .HasForeignKey(q => q.UserId);
        }
    }
}
