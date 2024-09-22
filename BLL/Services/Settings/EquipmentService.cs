namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IEquipmentService
{
    public Task<ApiResponse<bool>> Add(EquipmentViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(EquipmentViewModel vm);
    public Task<ApiResponse<EquipmentViewModel>> Get(int id);
    public Task<ApiResponse<List<EquipmentViewModel>>> GetAll();

}


public class EquipmentService : IEquipmentService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public EquipmentService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(EquipmentViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<Equipment>(_mapper.Map<Equipment>(value));
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
            _repository.Delete<Equipment>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(EquipmentViewModel value)
    {
        try
        {
            _repository.Update<Equipment>(_mapper.Map<Equipment>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<EquipmentViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Equipment>().ToListAsync();
            return ApiResponse<List<EquipmentViewModel>>.ApiOkResponse(_mapper.Map<List<EquipmentViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<EquipmentViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Equipment>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<EquipmentViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<EquipmentViewModel>.ApiOkResponse(_mapper.Map<EquipmentViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
