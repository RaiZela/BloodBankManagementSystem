using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface ISuspensionReasonService
{
    public Task<ApiResponse<bool>> Add(SuspensionReasonViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(SuspensionReasonViewModel clinicsVm);
    public Task<ApiResponse<SuspensionReasonViewModel>> Get(int id);
    public Task<ApiResponse<List<SuspensionReasonViewModel>>> GetAll();

}


public class SuspensionReasonService : ISuspensionReasonService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public SuspensionReasonService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(SuspensionReasonViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<SuspensionReason>(_mapper.Map<SuspensionReason>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        try
        {
            _repository.Delete<SuspensionReason>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(SuspensionReasonViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<SuspensionReason>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<SuspensionReason>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<SuspensionReasonViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<SuspensionReason>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<SuspensionReasonViewModel>>.ApiOkResponse(_mapper.Map<List<SuspensionReasonViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<SuspensionReasonViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<SuspensionReason>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<SuspensionReasonViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<SuspensionReasonViewModel>.ApiOkResponse(_mapper.Map<SuspensionReasonViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}