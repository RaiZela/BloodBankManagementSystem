using Microsoft.AspNetCore.Identity;

namespace DAL.Data.DatabaseModels.User;

public class Role : IdentityRole
{
    public Role(string roleName) : base(roleName)
    {
    }

    public Role()
    {

    }
}
