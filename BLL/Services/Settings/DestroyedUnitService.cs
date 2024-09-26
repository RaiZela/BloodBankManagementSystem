using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IDestroyedUnitService
{
    public Task<ApiResponse<bool>> Add(DestroyedUnitViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DestroyedUnitViewModel vm);
    public Task<ApiResponse<DestroyedUnitViewModel>> Get(int id);
    public Task<ApiResponse<List<DestroyedUnitViewModel>>> GetAll();

}


public class DestroyedUnitService : IDestroyedUnitService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DestroyedUnitService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(DestroyedUnitViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<DestroyedUnit>(_mapper.Map<DestroyedUnit>(value));
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
            _repository.Delete<DestroyedUnit>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DestroyedUnitViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<DestroyedUnit>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            _repository.Update<DestroyedUnit>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DestroyedUnitViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<DestroyedUnit>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<DestroyedUnitViewModel>>.ApiOkResponse(_mapper.Map<List<DestroyedUnitViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DestroyedUnitViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<DestroyedUnit>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DestroyedUnitViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DestroyedUnitViewModel>.ApiOkResponse(_mapper.Map<DestroyedUnitViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
