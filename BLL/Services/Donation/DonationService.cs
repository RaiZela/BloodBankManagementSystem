using BloodBankManagementSystem.BLL;

namespace BLL.Services.Donation;

public interface IDonationService
{
    public Task<ApiResponse<bool>> Add(DonationViewModel Donation);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonationViewModel Donation);
    public Task<ApiResponse<DonationViewModel>> Get(int id);
    public Task<ApiResponse<List<DonationViewModel>>> GetAll();
}

public class DonationService : IDonationService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DonationService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(DonationViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<DAL.Data.DatabaseModels.Donation>(_mapper.Map<DAL.Data.DatabaseModels.Donation>(value));
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
            _repository.Delete<DAL.Data.DatabaseModels.Donation>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DonationViewModel value)
    {
        try
        {
            var donation = await _repository.GetQueryable<DAL.Data.DatabaseModels.Donation>(x=>x.ID== value.ID).FirstOrDefaultAsync();
            if (donation == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<DAL.Data.DatabaseModels.Donation>(_mapper.Map(value, donation));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DonationViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<DAL.Data.DatabaseModels.Donation>(x=>!x.IsDeleted).ToListAsync();
            return ApiResponse<List<DonationViewModel>>.ApiOkResponse(_mapper.Map<List<DonationViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DonationViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<DAL.Data.DatabaseModels.Donation>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DonationViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DonationViewModel>.ApiOkResponse(_mapper.Map<DonationViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

