namespace BloodBankManagementSystem.BLL.Services.Questions;

public interface IQuestionService
{
    Task<ApiResponse<bool>> CreateQuestionAsync(QuestionViewModel question);
    Task<ApiResponse<QuestionViewModel>> GetQuestionByIdAsync(int questionId);
    Task<ApiResponse<IEnumerable<QuestionViewModel>>> GetAllQuestionsAsync();
    Task<ApiResponse<bool>> UpdateQuestionAsync(QuestionViewModel question);
    Task<ApiResponse<bool>> DeleteQuestionAsync(int questionId);
    Task<ApiResponse<bool>> CreateAnswerAsync(AnswerViewModel answer);
    Task<ApiResponse<AnswerViewModel>> GetAnswerByIdAsync(int answerId);
    Task<ApiResponse<IEnumerable<AnswerViewModel>>> GetAllAnswersAsync();
    Task<ApiResponse<bool>> UpdateAnswerAsync(AnswerViewModel answer);
    Task<ApiResponse<bool>> DeleteAnswerAsync(int answerId);
}

public class QuestionService : IQuestionService
{
    private readonly IRepository<ApplicationDbContext> _repository;
    private readonly IMapper _mapper;

    public QuestionService(IRepository<ApplicationDbContext> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<bool>> CreateQuestionAsync(QuestionViewModel question)
    {
        try
        {
            await _repository.CreateAsync(_mapper.Map<Question>(question));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ApiResponse<QuestionViewModel>> GetQuestionByIdAsync(int questionId)
    {
        try
        {
            var question = await _repository.GetQueryable<Question>()
                                    .Include(q => q.Answers)
                                    .FirstOrDefaultAsync(q => q.ID == questionId);

            return ApiResponse<QuestionViewModel>.ApiOkResponse(_mapper.Map<QuestionViewModel>(question));
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ApiResponse<IEnumerable<QuestionViewModel>>> GetAllQuestionsAsync()
    {
        try
        {
            var questions = await _repository.GetQueryable<Question>()
                                    .Include(q => q.Answers)
                                    .ToListAsync();

            var result = _mapper.Map<IEnumerable<QuestionViewModel>>(questions);

            return ApiResponse<IEnumerable<QuestionViewModel>>.ApiOkResponse(result);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ApiResponse<bool>> UpdateQuestionAsync(QuestionViewModel question)
    {
        try
        {
            _repository.Update(_mapper.Map<Question>(question));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ApiResponse<bool>> DeleteQuestionAsync(int questionId)
    {
        try
        {
            var question = await _repository.GetQueryable<Question>()
                                    .Include(q => q.Answers)
                                    .FirstOrDefaultAsync(q => q.ID == questionId);
            if (question != null)
            {
                _repository.Delete(question);
                await _repository.SaveAsync();
            }
            return ApiResponse<bool>.ApiOkResponse(true);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<ApiResponse<bool>> CreateAnswerAsync(AnswerViewModel answer)
    {
        try
        {
            await _repository.CreateAsync(_mapper.Map<Answer>(answer));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ApiResponse<AnswerViewModel>> GetAnswerByIdAsync(int answerId)
    {
        try
        {
            var answer = await _repository.GetQueryable<Answer>()
                                    .FirstOrDefaultAsync(a => a.ID == answerId);

            return ApiResponse<AnswerViewModel>.ApiOkResponse(_mapper.Map<AnswerViewModel>(answer));

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ApiResponse<IEnumerable<AnswerViewModel>>> GetAllAnswersAsync()
    {
        try
        {
            var answers = await _repository.GetQueryable<Answer>().ToListAsync();
            return ApiResponse<IEnumerable<AnswerViewModel>>.ApiOkResponse(_mapper.Map<IEnumerable<AnswerViewModel>>(answers));

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ApiResponse<bool>> UpdateAnswerAsync(AnswerViewModel answer)
    {
        try
        {
            _repository.Update(_mapper.Map<Answer>(answer));
            await _repository.SaveAsync();
            return ApiResponse<bool>.ApiOkResponse(true);

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ApiResponse<bool>> DeleteAnswerAsync(int answerId)
    {
        try
        {
            var answer = await GetAnswerByIdAsync(answerId);
            if (answer != null)
            {
                _repository.Delete(answer);
                await _repository.SaveAsync();
                return ApiResponse<bool>.ApiOkResponse(true);
            }
            return ApiResponse<bool>.ApiOkResponse(false); 
        }
        catch (Exception ex)
        {

            throw;
        }

    }
}

