using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IDonationTherapyService
{
    public Task<ApiResponse<bool>> Add(DonationTherapyViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonationTherapyViewModel clinicsVm);
    public Task<ApiResponse<DonationTherapyViewModel>> Get(int id);
    public Task<ApiResponse<List<DonationTherapyViewModel>>> GetAll();

}


public class DonationTherapyService : IDonationTherapyService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DonationTherapyService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(DonationTherapyViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<DonationTherapy>(_mapper.Map<DonationTherapy>(value));
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
            _repository.Delete<DonationTherapy>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DonationTherapyViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<DonationTherapy>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            _repository.Update<DonationTherapy>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DonationTherapyViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<DonationTherapy>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<DonationTherapyViewModel>>.ApiOkResponse(_mapper.Map<List<DonationTherapyViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DonationTherapyViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<DonationTherapy>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DonationTherapyViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DonationTherapyViewModel>.ApiOkResponse(_mapper.Map<DonationTherapyViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}