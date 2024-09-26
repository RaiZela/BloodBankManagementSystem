using DAL.Data.DatabaseModels;

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
    private readonly IMessageService _messageService;
    public QuestionService(IRepository<ApplicationDbContext> repository, IMapper mapper, IMessageService messageService)
    {
        _repository = repository;
        _mapper = mapper;
        _messageService = messageService;
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
            var question = await _repository.GetQueryable<Question>(x => !x.IsDeleted)
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
            var questions = await _repository.GetQueryable<Question>(x => !x.IsDeleted)
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
            var record = await _repository.GetQueryable<Question>(x => x.ID == question.ID)
                     .Include(x => x.Answers) 
                     .FirstOrDefaultAsync();

            if (record == null)
                return ApiResponse<bool>.ApiNotFoundResponse(_messageService.GetMessage(MessageKeys.Not_Found!));

            List<Answer> answers = record.Answers;
            foreach (var updatedAnswer in question.Answers)
            {
                var existingAnswer = answers.FirstOrDefault(x => x.ID == updatedAnswer.ID);

                if (existingAnswer != null && existingAnswer.ID != 0)
                {
                    _mapper.Map(updatedAnswer, existingAnswer);
                }
                else
                {
                    answers.Add(_mapper.Map<Answer>(updatedAnswer));
                }
            }

            answers.RemoveAll(a => !question.Answers.Any(x => x.ID == a.ID));

            record.Answers = answers;
            _mapper.Map(question, record);

            _repository.Update(record);
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
            var answer = await _repository.GetQueryable<Answer>(x => !x.IsDeleted)
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
            var answers = await _repository.GetQueryable<Answer>(x => !x.IsDeleted).ToListAsync();
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

