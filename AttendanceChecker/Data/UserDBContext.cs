using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace AttendanceChecker.Models
{

    public class UserDBContext : DbContext
    {
        
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AttendanceModel> Attendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.UserId); // Define the primary key

            // Other configurations

            base.OnModelCreating(modelBuilder);
        }
        //public string UserId { get; internal set; }
        //public UserModel Username { get; internal set; }
    }
}
