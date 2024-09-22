namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IProblemService
{
    public Task<ApiResponse<bool>> Add(ProblemViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ProblemViewModel clinicsVm);
    public Task<ApiResponse<ProblemViewModel>> Get(int id);
    public Task<ApiResponse<List<ProblemViewModel>>> GetAll();

}


public class ProblemService : IProblemService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ProblemService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ProblemViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<Problem>(_mapper.Map<Problem>(value));
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
            _repository.Delete<Problem>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ProblemViewModel value)
    {
        try
        {
            _repository.Update<Problem>(_mapper.Map<Problem>(value));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ProblemViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Problem>().ToListAsync();
            return ApiResponse<List<ProblemViewModel>>.ApiOkResponse(_mapper.Map<List<ProblemViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ProblemViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Problem>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ProblemViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ProblemViewModel>.ApiOkResponse(_mapper.Map<ProblemViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}