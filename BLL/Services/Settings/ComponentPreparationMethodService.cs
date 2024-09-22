namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IComponentPreparationMethodService
{
    public Task<ApiResponse<bool>> Add(ComponentPreparationMethodViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ComponentPreparationMethodViewModel vm);
    public Task<ApiResponse<ComponentPreparationMethodViewModel>> Get(int id);
    public Task<ApiResponse<List<ComponentPreparationMethodViewModel>>> GetAll();

}


public class ComponentPreparationMethodService : IComponentPreparationMethodService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ComponentPreparationMethodService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ComponentPreparationMethodViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<ComponentPreparationMethod>(_mapper.Map<ComponentPreparationMethod>(value));
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
            _repository.Delete<ComponentPreparationMethod>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ComponentPreparationMethodViewModel value)
    {
        try
        {
            _repository.Update<ComponentPreparationMethod>(_mapper.Map<ComponentPreparationMethod>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ComponentPreparationMethodViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<ComponentPreparationMethod>().ToListAsync();
            return ApiResponse<List<ComponentPreparationMethodViewModel>>.ApiOkResponse(_mapper.Map<List<ComponentPreparationMethodViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ComponentPreparationMethodViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<ComponentPreparationMethod>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ComponentPreparationMethodViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ComponentPreparationMethodViewModel>.ApiOkResponse(_mapper.Map<ComponentPreparationMethodViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
