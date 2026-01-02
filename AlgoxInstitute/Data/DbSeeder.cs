using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using AlgoxInstitute.Models;

namespace Algox.Data
{
	public static class DbSeeder
	{
		public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
		{
			// Identity Managers (required)
			var userManager = service.GetRequiredService<UserManager<IdentityUser>>();
			var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

			// 1. Create Roles if they don't exist
			string[] roleNames = { "Admin", "Teacher", "Student" };
			foreach (var roleName in roleNames)
			{
				if (!await roleManager.RoleExistsAsync(roleName))
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}

			// 2. Create the Super Admin User
			var adminEmail = "admin@institute.com";
			var adminUser = await userManager.FindByEmailAsync(adminEmail);

			if (adminUser == null)
			{
				var newAdmin = new IdentityUser
				{
					UserName = adminEmail,
					Email = adminEmail,
					EmailConfirmed = true
				};

				// Password must be strong (Uppercase, symbol, number)
				var result = await userManager.CreateAsync(newAdmin, "Admin@123");

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(newAdmin, "Admin");
				}
			}
		}
	}
}