using DAL.Data.DatabaseModels;

namespace BloodBankManagementSystem.BLL.Services;

public interface IExaminationService
{

    #region Examinations
    Task<ApiResponse<bool>> CreateExaminationAsync(ExaminationViewModel examination);
    Task<ApiResponse<ExaminationViewModel>> GetExaminationByIdAsync(int id);
    Task<ApiResponse<List<ExaminationViewModel>>> GetAllExaminationsAsync();
    Task<ApiResponse<bool>> UpdateExaminationAsync(ExaminationViewModel examination);
    Task<ApiResponse<bool>> DeleteExaminationAsync(int examination);
    Task<ApiResponse<List<DonationExaminationViewModel>>> GetDonorFormExaminationsAsync();
    #endregion Examinations

    #region ReferenceValues
    Task<ApiResponse<bool>> AddReferenceValueAsync(ReferenceValueViewModel referenceValue);
    Task<ApiResponse<ReferenceValueViewModel>> GetReferenceValueByIdAsync(int referenceValueId);
    Task<ApiResponse<IEnumerable<ReferenceValueViewModel>>> GetAllReferenceValuesAsync();
    Task<ApiResponse<bool>> UpdateReferenceValueAsync(ReferenceValueViewModel referenceValue);
    Task<ApiResponse<bool>> DeleteReferenceValueAsync(int referenceValueId);
    #endregion ReferenceValues
}
public class ExaminationService : IExaminationService
{
    private readonly IRepository<ApplicationDbContext> _repository;
    private readonly IMapper _mapper;
    private readonly IMessageService _messageService;

    public ExaminationService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService messageService)
    {
        _repository = repository;
        _mapper = mapper;
        _messageService = messageService;
    }



    #region Examinations 
    public async Task<ApiResponse<bool>> CreateExaminationAsync(ExaminationViewModel examination)
    {
        try
        {
            var createdExamination = await _repository.CreateAsync(_mapper.Map<Examination>(examination));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<ExaminationViewModel>> GetExaminationByIdAsync(int examinationId)
    {
        try
        {
            var examination = await _repository.GetQueryable<Examination>(x => !x.IsDeleted)
                                               .FirstOrDefaultAsync(e => e.ID == examinationId);

            return ApiResponse<ExaminationViewModel>.ApiOkResponse(_mapper.Map<ExaminationViewModel>(examination));
        }
        catch (Exception ex)
        {
            return ApiResponse<ExaminationViewModel>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<List<ExaminationViewModel>>> GetAllExaminationsAsync()
    {
        try
        {
            var examinations = await _repository.GetQueryable<Examination>(x => !x.IsDeleted).Include(x=>x.ReferenceValues.Where(x=>!x.IsDeleted)).ToListAsync();
            return ApiResponse<List<ExaminationViewModel>>.ApiOkResponse(_mapper.Map<List<ExaminationViewModel>>(examinations));
        }
        catch (Exception ex)
        {
            return ApiResponse<List<ExaminationViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }
    public async Task<ApiResponse<List<DonationExaminationViewModel>>> GetDonorFormExaminationsAsync()
    {
        try
        {
            var examinations = await _repository.GetQueryable<Examination>(x => !x.IsDeleted).Include(x => x.ReferenceValues.Where(x => !x.IsDeleted)).ToListAsync();

            var result = _mapper.Map<List<DonationExaminationViewModel>>(examinations);
            return ApiResponse<List<DonationExaminationViewModel>>.ApiOkResponse(result);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<DonationExaminationViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> UpdateExaminationAsync(ExaminationViewModel examination)
    {
        try
        {
            var record = await _repository.GetQueryable<Examination>(x => x.ID == examination.ID).Include(x=>x.ReferenceValues).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            List<ReferenceValue> referenceValues = record.ReferenceValues == null ? new List<ReferenceValue>() : record.ReferenceValues;

            foreach (var updated in examination.ReferenceValues)
            {
                var existing = referenceValues.FirstOrDefault(x => x.ID == updated.ID);

                if (existing!= null && existing.ID != 0)
                {
                    _mapper.Map(updated, existing);
                }
                else
                {
                    referenceValues.Add(_mapper.Map<ReferenceValue>(updated));
                }
            }

            referenceValues.RemoveAll(a => !examination.ReferenceValues.Any(x => x.ID == a.ID));

            _mapper.Map(examination, record);
            record.ReferenceValues = referenceValues;

            _repository.Update(record);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> DeleteExaminationAsync(int examinationId)
    {
        try
        {
            var examination = await _repository.GetQueryable<Examination>()
                                               .FirstOrDefaultAsync(e => e.ID == examinationId);
            if (examination == null)
            {
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            }

            _repository.Delete(examination);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    #endregion Examinations

    #region ReferenceValues
    public async Task<ApiResponse<bool>> AddReferenceValueAsync(ReferenceValueViewModel referenceValue)
    {
        try
        {
            var existingReference = await _repository.GetQueryable<ReferenceValue>()
                                                    .FirstOrDefaultAsync(r => r.ExaminationID == referenceValue.ExaminationID);
            if (existingReference != null)
            {
                return ApiResponse<bool>.ApiBadRequestResponse(_messageService.GetMessage(MessageKeys.Reference_Value_Already_Exists!));
            }

            var createdReference = await _repository.CreateAsync(_mapper.Map<ReferenceValue>(referenceValue));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<ReferenceValueViewModel>> GetReferenceValueByIdAsync(int referenceValueId)
    {
        try
        {
            var referenceValue = await _repository.GetQueryable<ReferenceValue>(x => !x.IsDeleted)
                                                  .FirstOrDefaultAsync(r => r.ID == referenceValueId);
            if (referenceValue == null)
            {
                return ApiResponse<ReferenceValueViewModel>.ApiNotFoundResponse($"Reference value with ID {referenceValueId} not found.");
            }
            return ApiResponse<ReferenceValueViewModel>.ApiOkResponse(_mapper.Map<ReferenceValueViewModel>(referenceValue));
        }
        catch (Exception ex)
        {
            return ApiResponse<ReferenceValueViewModel>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<IEnumerable<ReferenceValueViewModel>>> GetAllReferenceValuesAsync()
    {
        try
        {
            var referenceValues = await _repository.GetQueryable<ReferenceValue>(x => !x.IsDeleted).ToListAsync();
            return ApiResponse<IEnumerable<ReferenceValueViewModel>>.ApiOkResponse(_mapper.Map<IEnumerable<ReferenceValueViewModel>>(referenceValues));
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<ReferenceValueViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> UpdateReferenceValueAsync(ReferenceValueViewModel referenceValue)
    {
        try
        {
            var record = await _repository.GetQueryable<Examination>(x => x.ID == referenceValue.ID).FirstOrDefaultAsync();
            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            _repository.Update(_mapper.Map(referenceValue, record));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> DeleteReferenceValueAsync(int referenceValueId)
    {
        try
        {
            var referenceValue = await _repository.GetQueryable<ReferenceValue>()
                                                  .FirstOrDefaultAsync(r => r.ID == referenceValueId);
            if (referenceValue == null)
            {
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));
            }

            _repository.Delete(referenceValue);
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    #endregion ReferenceValues
}

