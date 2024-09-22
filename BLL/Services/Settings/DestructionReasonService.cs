namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IDestructionReasonService
{
    public Task<ApiResponse<bool>> Add(DestructionReasonViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DestructionReasonViewModel vm);
    public Task<ApiResponse<DestructionReasonViewModel>> Get(int id);
    public Task<ApiResponse<List<DestructionReasonViewModel>>> GetAll();

}


public class DestructionReasonService : IDestructionReasonService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DestructionReasonService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(DestructionReasonViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<DestructionReason>(_mapper.Map<DestructionReason>(value));
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
            _repository.Delete<DestructionReason>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DestructionReasonViewModel value)
    {
        try
        {
            _repository.Update<DestructionReason>(_mapper.Map<DestructionReason>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DestructionReasonViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<DestructionReason>().ToListAsync();
            return ApiResponse<List<DestructionReasonViewModel>>.ApiOkResponse(_mapper.Map<List<DestructionReasonViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DestructionReasonViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<DestructionReason>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DestructionReasonViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DestructionReasonViewModel>.ApiOkResponse(_mapper.Map<DestructionReasonViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
