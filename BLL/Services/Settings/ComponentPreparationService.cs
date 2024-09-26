using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IComponentPreparationService
{
    public Task<ApiResponse<bool>> Add(ComponentPreparationViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ComponentPreparationViewModel vm);
    public Task<ApiResponse<ComponentPreparationViewModel>> Get(int id);
    public Task<ApiResponse<List<ComponentPreparationViewModel>>> GetAll();

}


public class ComponentPreparationService : IComponentPreparationService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ComponentPreparationService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ComponentPreparationViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<ComponentPreparation>(_mapper.Map<ComponentPreparation>(value));
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
            _repository.Delete<ComponentPreparation>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ComponentPreparationViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<ComponentPreparation>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            _repository.Update<ComponentPreparation>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ComponentPreparationViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<ComponentPreparation>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<ComponentPreparationViewModel>>.ApiOkResponse(_mapper.Map<List<ComponentPreparationViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ComponentPreparationViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<ComponentPreparation>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ComponentPreparationViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ComponentPreparationViewModel>.ApiOkResponse(_mapper.Map<ComponentPreparationViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
