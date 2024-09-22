using DAL.Data.DatabaseModels.User;
using Microsoft.AspNetCore.Identity;

namespace BloodBankManagementSystem.DAL;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public List<UserPolicy> Policies { get; set; }
    public UserStatus Status { get; set; }

    public string PhotoBase64 { get; set; }
}
