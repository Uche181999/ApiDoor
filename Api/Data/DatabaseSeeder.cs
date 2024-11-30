using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseSeeder
{
    public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<DatabaseSeeder>>();
        logger.LogInformation("Starting database seeding...");

        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Log role seeding
        logger.LogInformation("Seeding roles...");
        var roles = new[] { "User", "Admin" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                logger.LogInformation($"Creating role: {role}");
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Log user seeding
        logger.LogInformation("Seeding admin user...");
        var adminEmail = "uche181999@gmail.com";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            logger.LogInformation("Admin user does not exist. Creating...");
            var adminUser = new AppUser
            {
                UserName = "uche181999",
                Email = adminEmail,
                FirstName = "uche",
                LastName = "emmanuel",
                OrganisationId = 1,
            };

            var result = await userManager.CreateAsync(adminUser, "Toegbwu@1812");
            if (result.Succeeded)
            {
                logger.LogInformation("Admin user created successfully. Assigning roles...");
                await userManager.AddToRolesAsync(adminUser, roles);
            }
            else
            {
                logger.LogError($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            logger.LogInformation("Admin user already exists.");
        }
    }
}
