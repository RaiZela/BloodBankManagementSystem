namespace BloodBankManagementSystem.BLL.Services.Settings;
public interface IDonationSymptomService
{
    public Task<ApiResponse<bool>> Add(DonationSymptomViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonationSymptomViewModel clinicsVm);
    public Task<ApiResponse<DonationSymptomViewModel>> Get(int id);
    public Task<ApiResponse<List<DonationSymptomViewModel>>> GetAll();

}


public class DonationSymptomService : IDonationSymptomService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DonationSymptomService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(DonationSymptomViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<DonationSymptom>(_mapper.Map<DonationSymptom>(value));
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
            _repository.Delete<DonationSymptom>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DonationSymptomViewModel value)
    {
        try
        {
            _repository.Update<DonationSymptom>(_mapper.Map<DonationSymptom>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DonationSymptomViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<DonationSymptom>().ToListAsync();
            return ApiResponse<List<DonationSymptomViewModel>>.ApiOkResponse(_mapper.Map<List<DonationSymptomViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DonationSymptomViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<DonationSymptom>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DonationSymptomViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DonationSymptomViewModel>.ApiOkResponse(_mapper.Map<DonationSymptomViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
