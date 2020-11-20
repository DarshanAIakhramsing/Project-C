using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_C.Models;

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
        }

        public DbSet<SessionInfo> Session { get; set; }

        public DbSet<SessionConfirmation> SessionConfirmation { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
