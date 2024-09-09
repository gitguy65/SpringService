using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 
using SpringApi.Model;

namespace SpringApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // 
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(u => u.UserProfile)
                .WithMany(b => b.Bookings)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<History>()
                .HasOne(u => u.UserProfile)
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

            modelBuilder.Entity<Payment>()
                .HasOne(u => u.UserProfile)
                .WithMany(b => b.Payments)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
        }
    }
}
