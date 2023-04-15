using Microsoft.AspNetCore.Identity;
using WebAssignment.Models;
namespace WebAssignment.Areas.Identity.Data
{
    public class ContextSeed
    {   
        public static async Task SeedRolesAsync(UserManager<WebAssignmentUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.basic.ToString()));

        }
        public static async Task SuperSeedRolesAsync(UserManager<WebAssignmentUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var admin = new WebAssignmentUser
            {
                UserName = "admin",
                Email = "admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u=> u.Id != admin.Id))
            {
                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin, "123Password1$");
                    await userManager.AddToRoleAsync(admin, Enum.Roles.admin.ToString());
                    

                }
            }
        }
    }
}
