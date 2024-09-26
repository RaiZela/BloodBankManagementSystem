using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IBagTypeService
{
    public Task<ApiResponse<bool>> Add(BagTypeViewModel vm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(BagTypeViewModel vm);
    public Task<ApiResponse<BagTypeViewModel>> Get(int id);
    public Task<ApiResponse<List<BagTypeViewModel>>> GetAll();

}


public class BagTypeService : IBagTypeService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public BagTypeService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(BagTypeViewModel value)
    {
        try
        {
            var response = await _repository.CreateAsync<BagType>(_mapper.Map<BagType>(value));
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
            _repository.Delete<BagType>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(BagTypeViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<BagType>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            _repository.Update<BagType>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<BagTypeViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<BagType>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<BagTypeViewModel>>.ApiOkResponse(_mapper.Map<List<BagTypeViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<BagTypeViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<BagType>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<BagTypeViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<BagTypeViewModel>.ApiOkResponse(_mapper.Map<BagTypeViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
