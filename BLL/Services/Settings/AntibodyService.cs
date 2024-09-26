using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;
public interface IAntibodyService
{
    public Task<ApiResponse<bool>> Add(AntibodyViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(AntibodyViewModel clinicsVm);
    public Task<ApiResponse<AntibodyViewModel>> Get(int id);
    public Task<ApiResponse<List<AntibodyViewModel>>> GetAll();

}


public class AntibodyService : IAntibodyService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public AntibodyService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(AntibodyViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<Antibody>(_mapper.Map<Antibody>(value));
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
            _repository.Delete<Antibody>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(AntibodyViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<Antibody>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<Antibody>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<AntibodyViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Antibody>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<AntibodyViewModel>>.ApiOkResponse(_mapper.Map<List<AntibodyViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<AntibodyViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Antibody>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<AntibodyViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<AntibodyViewModel>.ApiOkResponse(_mapper.Map<AntibodyViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
