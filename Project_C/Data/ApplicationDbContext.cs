using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_C.Models;
using Project_C.Data;

namespace Project_C.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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
                entity.HasKey($"{nameof(UserMeeting.User)}Id", $"{nameof(UserMeeting.SessionInfo)}session_id");

                // Configure the many-to-many relation between User and Role
                entity.HasOne(u => u.User)
                    .WithMany(m => m.Meetings);
            });
        }

        /*
        protected override void OnModelCreating_Meetings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMeeting>(entity =>
            {
                //  Add composite primary key on UserId and RoleId
                entity.HasKey($"{nameof(UserMeeting.User)}Id", $"{nameof(UserMeeting.Session)}session_id");

                // Configure the many-to-many relation between User and Role
                entity.HasOne(ur => ur.User)
                    .WithMany(m => m.Meetings);
            });
        }
        */

        public DbSet<SessionInfo> Session { get; set; }

        public DbSet<SessionConfirmation> SessionConfirmation { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<SessionModel> SessionModel { get; set; }

        public DbSet<UserMeeting> UserMeetings { get; set; }
    }
}
