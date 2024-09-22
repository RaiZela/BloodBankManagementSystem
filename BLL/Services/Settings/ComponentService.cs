namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IComponentService
{
    public Task<ApiResponse<bool>> Add(ComponentViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ComponentViewModel vm);
    public Task<ApiResponse<ComponentViewModel>> Get(int id);
    public Task<ApiResponse<List<ComponentViewModel>>> GetAll();

}


public class ComponentService : IComponentService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ComponentService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ComponentViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<Component>(_mapper.Map<Component>(value));
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
            _repository.Delete<Component>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ComponentViewModel value)
    {
        try
        {
            _repository.Update<Component>(_mapper.Map<Component>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ComponentViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Component>().ToListAsync();
            return ApiResponse<List<ComponentViewModel>>.ApiOkResponse(_mapper.Map<List<ComponentViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ComponentViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Component>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ComponentViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ComponentViewModel>.ApiOkResponse(_mapper.Map<ComponentViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
