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
            modelBuilder.Entity<Booking>()
                 .HasOne(u => u.User)
                 .WithMany(b => b.Bookings)
                 .HasForeignKey(u => u.UserId)
                 .IsRequired();

            modelBuilder.Entity<History>()
                 .HasOne(u => u.User)
                 .WithMany(h => h.Histories)
                 .HasForeignKey(u => u.UserId)
                 .IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(u => u.ServiceUser)
                .WithMany(r => r.GivenReviews)
                .HasForeignKey(r => r.ServiceUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(u => u.ServiceProvider)
                .WithMany(r => r.ReceivedReviews)
                .HasForeignKey(r => r.ServiceProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
