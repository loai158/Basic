using Microsoft.AspNetCore.Identity;

namespace Task.Infrastructure.DataAccess
{
    public static class DbInitializer
    {
        public static async System.Threading.Tasks.Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }

}
