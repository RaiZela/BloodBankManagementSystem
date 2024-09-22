namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IComponentStorageSystemService
{
    public Task<ApiResponse<bool>> Add(ComponentStorageSystemViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ComponentStorageSystemViewModel vm);
    public Task<ApiResponse<ComponentStorageSystemViewModel>> Get(int id);
    public Task<ApiResponse<List<ComponentStorageSystemViewModel>>> GetAll();

}


public class ComponentStorageSystemService : IComponentStorageSystemService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ComponentStorageSystemService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ComponentStorageSystemViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<ComponentStorageSystem>(_mapper.Map<ComponentStorageSystem>(value));
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
            _repository.Delete<ComponentStorageSystem>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ComponentStorageSystemViewModel value)
    {
        try
        {
            _repository.Update<ComponentStorageSystem>(_mapper.Map<ComponentStorageSystem>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ComponentStorageSystemViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<ComponentStorageSystem>().ToListAsync();
            return ApiResponse<List<ComponentStorageSystemViewModel>>.ApiOkResponse(_mapper.Map<List<ComponentStorageSystemViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ComponentStorageSystemViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<ComponentStorageSystem>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ComponentStorageSystemViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ComponentStorageSystemViewModel>.ApiOkResponse(_mapper.Map<ComponentStorageSystemViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
