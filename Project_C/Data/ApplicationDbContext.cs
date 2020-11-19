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

        public DbSet<SessionInfo> Session { get; set; }

        public DbSet<SessionConfirmation> SessionConfirmation { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }
    }
}
