using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services.Settings;

public interface IReactionService
{
    public Task<ApiResponse<bool>> Add(ReactionViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ReactionViewModel clinicsVm);
    public Task<ApiResponse<ReactionViewModel>> Get(int id);
    public Task<ApiResponse<List<ReactionViewModel>>> GetAll();

}


public class ReactionService : IReactionService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public ReactionService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<bool>> Add(ReactionViewModel value)
    {
        try
        {
            var clinic = await _repository.CreateAsync<Reaction>(_mapper.Map<Reaction>(value));
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
            _repository.Delete<Reaction>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(ReactionViewModel value)
    {
        try
        {
            var record = await _repository.GetQueryable<Reaction>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<Reaction>(_mapper.Map(value, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<ReactionViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Reaction>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<List<ReactionViewModel>>.ApiOkResponse(_mapper.Map<List<ReactionViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<ReactionViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Reaction>(x => x.ID == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<ReactionViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<ReactionViewModel>.ApiOkResponse(_mapper.Map<ReactionViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}