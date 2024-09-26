using DAL.Data.DatabaseModels.User;
using Shared;
using System.Collections.Generic;

namespace BloodBankManagementSystem.BLL.Services.Policies;
public interface IPolicyService
{
    Task<ApiResponse<IEnumerable<PolicyViewModel>>> GetAllPoliciesAsync();
    Task<ApiResponse<PolicyViewModel>> GetPolicyByIdAsync(string id);
    Task<ApiResponse<bool>> AddPolicyAsync(PolicyViewModel policy);
    Task<ApiResponse<bool>> UpdatePolicyAsync(PolicyViewModel policy);
    Task<ApiResponse<bool>> DeletePolicyAsync(string id);
    Task<ApiResponse<List<UserPolicyViewModel>>> GetPoliciesByUserIdAsync(string userId);
    Task<ApiResponse<bool>> AssignPolicyToUserAsync(string userId, string policyId);
    Task<ApiResponse<bool>> RemovePolicyFromUserAsync(string userId, string policyId);
}

public class PolicyService : IPolicyService
{
    private readonly IRepository<ApplicationDbContext> _repository;
    private readonly IMapper _mapper;
    private readonly IMessageService _messageService;
    public PolicyService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService messageService)
    {
        _mapper = mapper;
        _repository = repository;
        _messageService = messageService;
    }

    public async Task<ApiResponse<IEnumerable<PolicyViewModel>>> GetAllPoliciesAsync()
    {
        var policies = await _repository.GetQueryable<Policy>(x => !x.IsDeleted).ToListAsync();

        if (policies == null || policies.Count() == 0)
            return ApiResponse<IEnumerable<PolicyViewModel>>.ApiNoContentResponse();


        return ApiResponse<IEnumerable<PolicyViewModel>>.ApiOkResponse(_mapper.Map<List<PolicyViewModel>>(policies));
    }

    public async Task<ApiResponse<PolicyViewModel>> GetPolicyByIdAsync(string id)
    {
        var policy = await _repository.GetQueryable<Policy>((Policy policy) => policy.ID == id && !policy.IsDeleted).FirstOrDefaultAsync();

        if (policy == null)
            return ApiResponse<PolicyViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

        return ApiResponse<PolicyViewModel>.ApiOkResponse(_mapper.Map<PolicyViewModel>(policy));
    }

    public async Task<ApiResponse<bool>> AddPolicyAsync(PolicyViewModel policy)
    {
        try
        {
            var policyRecord = _mapper.Map<Policy>(policy);
            policyRecord.ID = (new Guid()).ToString();
            await _repository.CreateAsync(policyRecord);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
            //throw;
        }
    }

    public async Task<ApiResponse<bool>> UpdatePolicyAsync(PolicyViewModel policy)
    {
        try
        {
            _repository.Update(_mapper.Map<Policy>(policy));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
            //throw;
        }

    }

    public async Task<ApiResponse<bool>> DeletePolicyAsync(string id)
    {
        try
        {
            _repository.Delete<Policy>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
            //throw;
        }
    }

    public async Task<ApiResponse<List<UserPolicyViewModel>>> GetPoliciesByUserIdAsync(string userId)
    {
        try
        {
            var userPolicies = await _repository.GetQueryable<ApplicationUser>((ApplicationUser user) => user.Id == userId)
                .Include(up => up.Policies)
                .ThenInclude(x => x.Policy)
                .Select(up => up.Policies)
                .FirstOrDefaultAsync();

            if(userPolicies == null || userPolicies.Count() == 0)
                return ApiResponse<List<UserPolicyViewModel>>.ApiNoContentResponse();

            return ApiResponse<List<UserPolicyViewModel>>.ApiOkResponse(_mapper.Map<List<UserPolicyViewModel>>(userPolicies));

        }
        catch (Exception ex)
        {
            return ApiResponse<List<UserPolicyViewModel>>.ApiInternalServerErrorResponse(ex.Message);
            //throw;
        }
    }

    public async Task<ApiResponse<bool>> AssignPolicyToUserAsync(string userId, string policyId)
    {
        try
        {
            await _repository.CreateAsync(new UserPolicy { UserId = userId, PolicyId = policyId });
            await _repository.SaveAsync();

            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
            //throw;
        }
    }

    public async Task<ApiResponse<bool>> RemovePolicyFromUserAsync(string userId, string policyId)
    {
        try
        {
            var userPolicy = await _repository.GetQueryable<UserPolicy>(up => up.UserId == userId && up.PolicyId == policyId).FirstOrDefaultAsync();

            if (userPolicy == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            if (userPolicy != null)
            {
                _repository.Delete<UserPolicy>(userPolicy.ID);
                await _repository.SaveAsync();
            }

            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
            //throw;
        }
    }
}
