using Microsoft.AspNetCore.Identity;

namespace MachineSimulation.App.Infrastructe.Extensions
{
    public static class ApplicationExtension
    {
        public static async Task ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "admin.123";

            using var scope = app.ApplicationServices.CreateAsyncScope();
            var serviceProvider = scope.ServiceProvider;
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            try
            {
                logger.LogInformation("Starting to configure the default admin user.");
                IdentityUser user = await userManager.FindByNameAsync(adminUser);
                if (user == null)
                {
                    logger.LogInformation("Admin user not found, creating new admin user.");

                    user = new IdentityUser
                    {
                        UserName = adminUser,
                        Email = "admin@example.com", // Email eklenmesi önerilir
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(user, adminPassword);
                    if (!result.Succeeded)
                    {
                        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                        logger.LogError($"Admin user could not be created! Errors: {errors}");
                        throw new Exception($"Admin user could not be created! Errors: {errors}");
                    }

                    logger.LogInformation("Admin user created successfully.");

                    var roleResult = await userManager.AddToRolesAsync(user, roleManager.Roles.Select(n => n.Name).ToList());
                    if (!roleResult.Succeeded)
                    {
                        var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                        logger.LogError($"System have problems with role definition for admin! Errors: {errors}");
                        throw new Exception($"System have problems with role definition for admin! Errors: {errors}");
                    }

                    logger.LogInformation("Roles assigned to admin user successfully.");
                }
                else
                {
                    logger.LogInformation("Admin user already exists.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the admin user.");
                throw;
            }
        }
    }
}
