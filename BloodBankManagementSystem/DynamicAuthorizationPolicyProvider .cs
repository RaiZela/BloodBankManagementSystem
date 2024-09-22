using BloodBankManagementSystem.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BloodBankManagementSystem;

public class DynamicAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private readonly IServiceProvider _serviceProvider;

    public DynamicAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, IServiceProvider serviceProvider)
        : base(options)
    {
        _serviceProvider = serviceProvider;
    }

    public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        // Access the DB context via the service provider
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Fetch the policy from the database
            var policyData = await dbContext.Policies
                .FirstOrDefaultAsync(p => p.Name == policyName);

            if (policyData != null)
            {
                // Build the policy based on the claim and value from the database
                var policy = new AuthorizationPolicyBuilder();
                policy.RequireClaim(policyData.RequiredClaim, policyData.ClaimValue);
                return policy.Build();
            }
        }

        // If policy not found in the database, fall back to default policies
        return await base.GetPolicyAsync(policyName);
    }
}
