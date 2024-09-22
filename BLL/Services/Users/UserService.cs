using BloodBankManagementSystem.BLL;
using Microsoft.Extensions.Logging;
using System.Security.Policy;
using static General.Enums;

namespace BLL.Services.Users;

public interface IUserService
{
    Task<ApiResponse<IEnumerable<ApplicationUserViewModel>>> GetAllUsersAsync();
    Task<ApiResponse<ApplicationUserViewModel>> GetUserByIdAsync(string id);
    Task<ApiResponse<bool>> CreateUserAsync(ApplicationUserViewModel user);
    Task<ApiResponse<bool>> UpdateUserAsync(ApplicationUserViewModel user);
    Task<ApiResponse<bool>> DeleteUserAsync(string id);
}

public class UserService : IUserService
{
    private readonly IRepository<DbContext> _repository; // Use the appropriate DbContext type
    private readonly ILogger<UserService> _logger;
    private readonly IMapper _mapper;
    private readonly IMessageService _messageService;

    public UserService(IRepository<DbContext> repository, ILogger<UserService> logger, IMapper mapper, IMessageService messageService)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _messageService = messageService;
    }

    public async Task<ApiResponse<bool>> CreateUserAsync(ApplicationUserViewModel user)
    {
        try
        {
            var createdUser = await _repository.CreateAsync(_mapper.Map<ApplicationUser>(user));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating user");
            return ApiResponse<bool>.ApiInternalServerErrorResponse(e.Message ?? e.InnerException.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> UpdateUserAsync(ApplicationUserViewModel user)
    {
        try
        {
            if (!_repository.Exists<ApplicationUser>(x => x.Id == user.Id))
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update(_mapper.Map<ApplicationUser>(user));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating user");
            return ApiResponse<bool>.ApiInternalServerErrorResponse(e.Message ?? e.InnerException.Message);
            throw;
        }
    }

    public async Task<ApiResponse<bool>> DeleteUserAsync(string userId)
    {
        try
        {
            var user = await _repository.GetQueryable<ApplicationUser>(u => u.Id == userId).FirstOrDefaultAsync();
            if (user != null)
            {
                _repository.Delete(_mapper.Map<ApplicationUser>(user));
                await _repository.SaveAsync();
                return ApiResponse<bool>.ApiOkResponse(true);
            }
            else
            {
                _logger.LogWarning("User with id {UserId} not found for deletion", userId);
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting user");
            return ApiResponse<bool>.ApiInternalServerErrorResponse(e.Message ?? e.InnerException.Message);
            throw;
        }
    }

    public async Task<ApiResponse<ApplicationUserViewModel>> GetUserByIdAsync(string userId)
    {
        try
        {
            //kontrolli i rolit per te caktuar nese mund te shohi enabled apo disabled
            var user= await _repository.GetQueryable<ApplicationUser>(u => u.Id == userId && u.Status != General.Enums.UserStatus.Disabled).FirstOrDefaultAsync();

            if (user == null)
                return ApiResponse<ApplicationUserViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            return ApiResponse<ApplicationUserViewModel>.ApiOkResponse(_mapper.Map<ApplicationUserViewModel>(user));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving user");
            return ApiResponse<ApplicationUserViewModel>.ApiInternalServerErrorResponse(e.Message ?? e.InnerException.Message);
            throw;
        }
    }

    public async Task<ApiResponse<IEnumerable<ApplicationUserViewModel>>> GetAllUsersAsync()
    {
        try
        {
            var users = await _repository.GetQueryable<ApplicationUser>(u => u.Status != UserStatus.Disabled).ToListAsync();

            if (users == null || users.Count() == 0)
                return ApiResponse<IEnumerable<ApplicationUserViewModel>>.ApiNoContentResponse();

            return ApiResponse<IEnumerable<ApplicationUserViewModel>>.ApiOkResponse(_mapper.Map<IEnumerable<ApplicationUserViewModel>>(users));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving users");
            return ApiResponse<IEnumerable<ApplicationUserViewModel>>.ApiInternalServerErrorResponse(e.Message ?? e.InnerException.Message);
            throw;
        }
    }
}
