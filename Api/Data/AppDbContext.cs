using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Visit> Visits { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles =
            [
                new IdentityRole{
                    Id = "first-role-id",
                    Name ="User",
                    NormalizedName= "USER"
                    },
                new IdentityRole{
                    Id = "sec-role-id",
                    Name ="Admin",
                    NormalizedName ="ADMIN"
                    }

            ];


            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<Organisation>().HasData(new Organisation
            {
                Id = 1,
                Name = "my company",
                EmailDomain = "@mycompany.com"
            });
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new AppUser
            {
                Id = "first-user-id", // Unique ID
                UserName = "uche181999",
                NormalizedUserName = "UCHE18999",
                Email = "uche181999@gmail.com",
                NormalizedEmail = "UCHE181999@GMAIL.COM",
                EmailConfirmed = true,
                FirstName ="Uche",
                LastName ="Emmanuel",
                OrganisationId = 1,

            };
            user.PasswordHash = hasher.HashPassword(user, "Toegbwu@1812");
            builder.Entity<AppUser>().HasData(user);
            var  userRole =new [] {
                new IdentityUserRole<string>
                {
                UserId = "first-user-id",
                RoleId = "first-role-id" // Match this with the seeded Admin role ID
                },
             new IdentityUserRole<string>
                {
                UserId = "first-user-id",
                RoleId = "sec-role-id" // Match this with the seeded Admin role ID
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(userRole);

            }


        }

    }