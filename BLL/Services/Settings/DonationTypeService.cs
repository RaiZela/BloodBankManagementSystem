namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IDonationTypeService
{
    public Task<ApiResponse<bool>> Add(DonationTypeViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonationTypeViewModel clinicsVm);
    public Task<ApiResponse<DonationTypeViewModel>> Get(int id);
    public Task<ApiResponse<List<DonationTypeViewModel>>> GetAll();

}


public class DonationTypeService : IDonationTypeService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DonationTypeService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(DonationTypeViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<DonationType>(_mapper.Map<DonationType>(value));
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
            _repository.Delete<DonationType>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DonationTypeViewModel value)
    {
        try
        {
            _repository.Update<DonationType>(_mapper.Map<DonationType>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DonationTypeViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<DonationType>().ToListAsync();
            return ApiResponse<List<DonationTypeViewModel>>.ApiOkResponse(_mapper.Map<List<DonationTypeViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DonationTypeViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<DonationType>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DonationTypeViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DonationTypeViewModel>.ApiOkResponse(_mapper.Map<DonationTypeViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}