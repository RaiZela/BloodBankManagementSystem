using DAL.Data.DatabaseModels.User;
using Microsoft.AspNetCore.Identity;

namespace DAL.Data.Seed;

public static class RolesSeed
{
    public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new Role("Admin"));
        }
        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new Role("User"));
        }
        if (!await roleManager.RoleExistsAsync("Donor"))
        {
            await roleManager.CreateAsync(new Role("Donor"));
        }
        if (!await roleManager.RoleExistsAsync("BankPhysician"))
        {
            await roleManager.CreateAsync(new Role("User"));
        }
        if (!await roleManager.RoleExistsAsync("HospitalPhysician"))
        {
            await roleManager.CreateAsync(new Role("HospitalPhysician"));
        }

    }
}
