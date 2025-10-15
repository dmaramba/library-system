using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.Data
{
    public static class UserSeeder
    {

        public static async Task SeedAsyc(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new[] { "Administrator", "Member" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!roleResult.Succeeded)
                    {
                        var msg = string.Join("; ", roleResult.Errors.Select(e => $"{e.Code}:{e.Description}"));
                        throw new Exception($"Failed to create role '{role}': {msg}");
                    }
                }
            }

            var adminEmail = "admin@library.local";
            var adminPassword = "Admin#12345";
            var adminUserName = "admin";

            var admin = await userManager.FindByEmailAsync(adminEmail)
                      ?? await userManager.FindByNameAsync(adminUserName);
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "John",
                    LastName = "Doe",
                };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (!result.Succeeded)
                {
                    var message = string.Join(",", result.Errors.Select(x => $"{x.Code}:{x.Description}"));
                    throw new Exception($"Failed to create seed admin '{adminEmail}': {message}");
                }
            }
            else
            {
                if (!admin.EmailConfirmed)
                {
                    admin.EmailConfirmed = true;
                    await userManager.UpdateAsync(admin);
                }
            }

            if (!await userManager.IsInRoleAsync(admin, "Administrator"))
            {
                await userManager.AddToRoleAsync(admin, "Administrator");
            }

        }
    }
}
