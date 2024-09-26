using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IClinicsService
{
    public Task<ApiResponse<bool>> Add(ClinicsViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ClinicsViewModel clinicsVm);
    public Task<ApiResponse<ClinicsViewModel>> Get(int id);
    public Task<ApiResponse<List<ClinicsViewModel>>> GetAll();

}


public class ClinicsService : IClinicsService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ClinicsService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ClinicsViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<Clinic>(_mapper.Map<Clinic>(value));
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
            _repository.Delete<Clinic>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ClinicsViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<Clinic>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<Clinic>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ClinicsViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Clinic>(x=>!x.IsDeleted).ToListAsync();
            return ApiResponse<List<ClinicsViewModel>>.ApiOkResponse(_mapper.Map<List<ClinicsViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ClinicsViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Clinic>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ClinicsViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ClinicsViewModel>.ApiOkResponse(_mapper.Map<ClinicsViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
