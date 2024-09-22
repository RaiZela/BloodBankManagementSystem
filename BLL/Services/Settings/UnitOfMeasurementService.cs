using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IUnitOfMeasurementService
{
    public Task<ApiResponse<bool>> Add(UnitOfMeasurementViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(UnitOfMeasurementViewModel vm);
    public Task<ApiResponse<UnitOfMeasurementViewModel>> Get(int id);
    public Task<ApiResponse<List<UnitOfMeasurementViewModel>>> GetAll();

}


public class UnitOfMeasurementService : IUnitOfMeasurementService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public UnitOfMeasurementService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(UnitOfMeasurementViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<UnitOfMeasurement>(_mapper.Map<UnitOfMeasurement>(value));
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
            _repository.Delete<UnitOfMeasurement>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(UnitOfMeasurementViewModel value)
    {
        try
        {
            _repository.Update<UnitOfMeasurement>(_mapper.Map<UnitOfMeasurement>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<UnitOfMeasurementViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<UnitOfMeasurement>().ToListAsync();
            return ApiResponse<List<UnitOfMeasurementViewModel>>.ApiOkResponse(_mapper.Map<List<UnitOfMeasurementViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<UnitOfMeasurementViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<UnitOfMeasurement>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<UnitOfMeasurementViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<UnitOfMeasurementViewModel>.ApiOkResponse(_mapper.Map<UnitOfMeasurementViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
