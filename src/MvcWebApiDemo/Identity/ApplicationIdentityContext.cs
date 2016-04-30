using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace WebApplication1.Identity
{
    public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserProfilePicture> UserProfilePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<int>>().HasKey(o => o.UserId);
            builder.Entity<IdentityUserRole<int>>().HasKey(o => o.RoleId);

            builder.Entity<UserProfilePicture>()
          .HasOne(p => p.ApplicationUser)
          .WithMany(b => b.UserProfilePictures);

            builder.Entity<UserProfilePicture>()
            .HasKey(o => new { o.UserId, o.ImageType });

            builder.Entity<UserProfilePicture>()
          .Property(b => b.UserId)
          .HasColumnType("int");

            base.OnModelCreating(builder);
        }
    }
}
