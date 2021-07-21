using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
                                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                                IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(r => r.Role)
            .HasForeignKey(rl => rl.RoleId)
            .IsRequired();

            builder.Entity<Table>().HasData(
                new Table
                {
                    Id = 1,
                    Available = true,
                    status = "Available"
                },
                new Table
                {
                    Id = 2,
                    Available = false,
                    status = "Unavailable"
                },
                new Table
                {
                    Id = 3,
                    Available = true,
                    status = "Available"
                }
            );
        }
        public DbSet<Table> Tables { get; set; }

    }
}
