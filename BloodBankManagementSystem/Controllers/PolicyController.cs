using BloodBankManagementSystem.BLL.Services.Policies;
using DAL.Data.DatabaseModels.User;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyService _policyService;

    public PolicyController(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPolicies()
    {
        var policies = await _policyService.GetAllPoliciesAsync();
        return Ok(policies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPolicy(string id)
    {
        var policy = await _policyService.GetPolicyByIdAsync(id);
        if (policy == null)
            return NotFound();
        return Ok(policy);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePolicy([FromBody] PolicyViewModel policy)
    {
        await _policyService.AddPolicyAsync(policy);
        return CreatedAtAction(nameof(GetPolicy), new { id = policy.ID }, policy);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePolicy(string id, [FromBody] PolicyViewModel policy)
    {
        if (id != policy.ID)
            return BadRequest();

        await _policyService.UpdatePolicyAsync(policy);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(string id)
    {
        await _policyService.DeletePolicyAsync(id);
        return NoContent();
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetPoliciesByUserId(string userId)
    {
        var userPolicies = await _policyService.GetPoliciesByUserIdAsync(userId);
        return Ok(userPolicies);
    }

    [HttpPost("user/{userId}/assign/{policyId}")]
    public async Task<IActionResult> AssignPolicyToUser(string userId, string policyId)
    {
        await _policyService.AssignPolicyToUserAsync(userId, policyId);
        return NoContent();
    }

    [HttpDelete("user/{userId}/remove/{policyId}")]
    public async Task<IActionResult> RemovePolicyFromUser(string userId, string policyId)
    {
        await _policyService.RemovePolicyFromUserAsync(userId, policyId);
        return NoContent();
    }
}
