namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IBagManufacturerService
{
    public Task<ApiResponse<bool>> Add(BagManufacturerViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(BagManufacturerViewModel vm);
    public Task<ApiResponse<BagManufacturerViewModel>> Get(int id);
    public Task<ApiResponse<List<BagManufacturerViewModel>>> GetAll();

}


public class BagManufacturerService : IBagManufacturerService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public BagManufacturerService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(BagManufacturerViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<BagManufacturer>(_mapper.Map<BagManufacturer>(value));
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
            _repository.Delete<BagManufacturer>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(BagManufacturerViewModel value)
    {
        try
        {
            _repository.Update<BagManufacturer>(_mapper.Map<BagManufacturer>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<BagManufacturerViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<BagManufacturer>().ToListAsync();
            return ApiResponse<List<BagManufacturerViewModel>>.ApiOkResponse(_mapper.Map<List<BagManufacturerViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<BagManufacturerViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<BagManufacturer>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<BagManufacturerViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<BagManufacturerViewModel>.ApiOkResponse(_mapper.Map<BagManufacturerViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
