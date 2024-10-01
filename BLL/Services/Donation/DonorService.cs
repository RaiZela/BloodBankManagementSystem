using Microsoft.EntityFrameworkCore;
using static General.Enums;

namespace BloodBankManagementSystem.BLL.Services.Donation;

public interface IDonorService
{
    public Task<ApiResponse<int>> Add(DonorViewModel Donor);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonorViewModel Donor);
    public Task<ApiResponse<DonorViewModel>> Get(int id);
    public Task<ApiResponse<List<DonorViewModel>>> GetAll();
    public Task<ApiResponse<bool>> SubmitAnswers(List<QuestionaireViewModel> questionaires);
    public Task<ApiResponse<bool>> SuspendDonor(int donorID, int reasonID);
    Task<List<FullDonorViewModel>> GetDonorsWithDetailsAsync();
}

public class DonorService : IDonorService
{
    //private readonly ILogger _logger;
    public readonly IRepository<ApplicationDbContext> _repository;
    public readonly IMapper _mapper;
    public readonly IMessageService _messageService;
    public DonorService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService message)
    {
        //_logger = logger;
        _repository = repository;
        _mapper = mapper;
        _messageService = message;
    }
    public async Task<ApiResponse<int>> Add(DonorViewModel value)
    {
        try
        {
            var donor = await _repository.CreateAsync<Donor>(_mapper.Map<Donor>(value));
            await _repository.SaveAsync();
            return ApiResponse<int>.ApiOkResponse(donor.ID);

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
            _repository.Delete<Donor>(id);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<ApiResponse<bool>> Update(DonorViewModel value)
    {
        try
        {
            var donor = await _repository.GetQueryable<Donor>(x => x.ID == value.ID).FirstOrDefaultAsync();
            if (donor == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update<Donor>(_mapper.Map(value, donor));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<List<DonorViewModel>>> GetAll()
    {
        try
        {
            var response = await _repository.GetQueryable<Donor>().ToListAsync();
            return ApiResponse<List<DonorViewModel>>.ApiOkResponse(_mapper.Map<List<DonorViewModel>>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<DonorViewModel>> Get(int id)
    {
        try
        {
            var response = await _repository.GetQueryable<Donor>(x => x.ID == id).FirstOrDefaultAsync();
            if (response == null)
                return ApiResponse<DonorViewModel>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));


            return ApiResponse<DonorViewModel>.ApiOkResponse(_mapper.Map<DonorViewModel>(response));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<ApiResponse<bool>> SubmitAnswers(List<QuestionaireViewModel> questionaires)
    {
        try
        {
            var responses = _mapper.Map<List<Response>>(questionaires.Select(x => x.Response));

            var donor = await _repository.GetQueryable<Donor>(x => x.ID == responses.First().DonorID)
                .FirstOrDefaultAsync();

            if (donor == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            donor.QuestionaireResponses = responses;

            _repository.Update(donor);

            await _repository.SaveAsync();

            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task<ApiResponse<bool>> SuspendDonor(int donorID, int reasonID)
    {
        try
        {
            var donor = await _repository.GetQueryable<Donor>(x => x.ID == donorID).Include(x => x.SuspendedDonors).FirstOrDefaultAsync();
            if (donor is null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            var suspensionReason = await _repository.GetQueryable<SuspensionReason>(x => x.ID == reasonID).FirstOrDefaultAsync();

            if (suspensionReason is null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            donor.IsSuspended = true;

            if (donor.SuspendedDonors == null)
                donor.SuspendedDonors = new();

            donor.SuspendedDonors.Add(new SuspendedDonors()
            {
                DonorID = donorID,
                ReasonID = reasonID
            });


            _repository.Update<Donor>(donor);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task<List<FullDonorViewModel>> GetDonorsWithDetailsAsync()
    {
        var donors = await _repository.GetQueryable<Donor>(x=>!x.IsDeleted)
            .Include(d => d.City)
            .Include(d => d.Donations)
            .Include(d => d.QuestionaireResponses)
                 .ThenInclude(x => x.Question)
            .Include(d => d.SuspendedDonors)
                .ThenInclude(sd => sd.Reason).ThenInclude(x=>x.DurationUom)
            .Include(x => x.ExaminationResults)
                .ThenInclude(x => x.Examination)
                .OrderByDescending(x=>x.CreatedDate)
            .ToListAsync();

        return _mapper.Map<List<FullDonorViewModel>>(donors);
    }

}
