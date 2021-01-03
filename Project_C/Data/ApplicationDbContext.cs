using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_C.Models;
using System.Threading.Tasks;

namespace Project_C.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ILogger<ApplicationDbContext> logger)
            : base(options)
        {
            Log = logger;
        }
        
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<UserRole>(entity =>
			{
				//  Add composite primary key on UserId and RoleId
				entity.HasKey($"{nameof(UserRole.User)}Id", $"{nameof(UserRole.Role)}Id");

				// Configure the many-to-many relation between User and Role
				entity.HasOne(ur => ur.User)
					.WithMany(u => u.Roles);
			});

            modelBuilder.Entity<UserMeeting>(entity =>
            {
                //  Add composite primary key on UserId and RoleId
                entity.HasKey($"{nameof(UserMeeting.User)}Id", $"{nameof(UserMeeting.SessionInfo)}Id");

                // Configure the many-to-many relation between User and Role
                entity.HasOne(u => u.User)
                    .WithMany(m => m.Meetings);
            });

#if DEBUG
            // Seed database
            modelBuilder.Entity<Role>()
                .HasData(new Role[]
                {
                    new() { Id = -1, Name = "Organisator" }
                });
#endif
        }

        public override ValueTask DisposeAsync()
        {
            Log.LogInformation("Disposing {0} instance", GetType());
            return base.DisposeAsync();
        }

        public DbSet<SessionInfo> Session { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserMeeting> UserMeetings { get; set; }
        public ILogger<ApplicationDbContext> Log { get; }
    }
}
