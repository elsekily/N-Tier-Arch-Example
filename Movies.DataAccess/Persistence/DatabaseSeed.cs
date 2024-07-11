using Microsoft.AspNetCore.Identity;
using Movies.DataAccess.Identity;

namespace Movies.DataAccess.Persistence;

public class DatabaseSeed
{
    public class Seed
    {
        public static void SeedUsersAndRoles(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole<int> { Name = Roles.Admin }).Wait();
            }

            if (!userManager.Users.Any())
            {
                var admin = new User
                {
                    Email = "admin@movies.com",
                    UserName = "Admin",
                };
                userManager.CreateAsync(admin, "Admin-12345678900").Wait();
                admin = userManager.FindByEmailAsync(admin.Email).Result;
                userManager.AddToRoleAsync(admin, Roles.Admin).Wait();
            }
        }
    }
}
