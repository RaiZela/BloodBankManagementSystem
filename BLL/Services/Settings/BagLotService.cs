namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IBagLotService
{
    public Task<ApiResponse<bool>> Add(BagLotViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(BagLotViewModel vm);
    public Task<ApiResponse<BagLotViewModel>> Get(int id);
    public Task<ApiResponse<List<BagLotViewModel>>> GetAll();

}


public class BagLotService : IBagLotService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public BagLotService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(BagLotViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<BagLot>(_mapper.Map<BagLot>(value));
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
            _repository.Delete<BagLot>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(BagLotViewModel value)
    {
        try
        {
            _repository.Update<BagLot>(_mapper.Map<BagLot>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<BagLotViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<BagLot>().ToListAsync();
            return ApiResponse<List<BagLotViewModel>>.ApiOkResponse(_mapper.Map<List<BagLotViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<BagLotViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<BagLot>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<BagLotViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<BagLotViewModel>.ApiOkResponse(_mapper.Map<BagLotViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
