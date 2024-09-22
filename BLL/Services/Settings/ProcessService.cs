namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IProcessService
{
    public Task<ApiResponse<bool>> Add(ProcessViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ProcessViewModel vm);
    public Task<ApiResponse<ProcessViewModel>> Get(int id);
    public Task<ApiResponse<List<ProcessViewModel>>> GetAll();

}


public class ProcessService : IProcessService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ProcessService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ProcessViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<Process>(_mapper.Map<Process>(value));
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
            _repository.Delete<Process>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ProcessViewModel value)
    {
        try
        {
            _repository.Update<Process>(_mapper.Map<Process>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ProcessViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Process>().ToListAsync();
            return ApiResponse<List<ProcessViewModel>>.ApiOkResponse(_mapper.Map<List<ProcessViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ProcessViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Process>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ProcessViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ProcessViewModel>.ApiOkResponse(_mapper.Map<ProcessViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
