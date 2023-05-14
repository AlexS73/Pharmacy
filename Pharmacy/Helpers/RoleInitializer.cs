using System.Linq;
using Microsoft.AspNetCore.Identity;
using Pharmacy.Entity;
using System.Threading.Tasks;

namespace Pharmacy.Helpers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string adminEmail = "globaladmin@example.com";
            string password = "Qweasdzxc123!";

            if (await roleManager.FindByNameAsync("administrator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("administrator"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, DepartmentId = 1};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "administrator");
                    await userManager.AddToRoleAsync(admin, "user");
                }

            }
        }
    }
}
