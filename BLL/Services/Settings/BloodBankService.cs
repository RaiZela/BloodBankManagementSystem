using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IBloodBankService
{
    public Task<ApiResponse<bool>> Add(BloodBankViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(BloodBankViewModel clinicsVm);
    public Task<ApiResponse<BloodBankViewModel>> Get(int id);
    public Task<ApiResponse<List<BloodBankViewModel>>> GetAll();

}


public class BloodBankService : IBloodBankService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public BloodBankService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(BloodBankViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<Bank>(_mapper.Map<Bank>(value));
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
            _repository.Delete<Bank>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(BloodBankViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<Bank>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<Bank>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<BloodBankViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Bank>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<BloodBankViewModel>>.ApiOkResponse(_mapper.Map<List<BloodBankViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<BloodBankViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Bank>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<BloodBankViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<BloodBankViewModel>.ApiOkResponse(_mapper.Map<BloodBankViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
