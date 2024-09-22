namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface ICityService
{
    public Task<ApiResponse<bool>> Add(CityViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(CityViewModel clinicsVm);
    public Task<ApiResponse<CityViewModel>> Get(int id);
    public Task<ApiResponse<List<CityViewModel>>> GetAll();

}


public class CityService : ICityService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public CityService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(CityViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<City>(_mapper.Map<City>(value));
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
            _repository.Delete<City>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(CityViewModel value)
    {
        try
        {
            _repository.Update<City>(_mapper.Map<City>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<CityViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<City>().ToListAsync();
            return ApiResponse<List<CityViewModel>>.ApiOkResponse(_mapper.Map<List<CityViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<CityViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<City>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<CityViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<CityViewModel>.ApiOkResponse(_mapper.Map<CityViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
