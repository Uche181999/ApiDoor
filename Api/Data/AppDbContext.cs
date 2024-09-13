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

        protected override  void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Name ="User",
                    NormalizedName= "USER"
                    },
                new IdentityRole{
                    Name ="Admin",
                    NormalizedName ="ADMIN"
                    }

            };
            builder.Entity<IdentityRole>().HasData(roles);

        }



    }


}