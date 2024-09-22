using BloodBankManagementSystem.BLL.Services.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateQuestion([FromBody] QuestionViewModel question)
    {
        var result = await _questionService.CreateQuestionAsync(question);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestionById(int id)
    {
        var result = await _questionService.GetQuestionByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var result = await _questionService.GetAllQuestionsAsync();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateQuestion([FromBody] QuestionViewModel question)
    {
        var result = await _questionService.UpdateQuestionAsync(question);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        var result = await _questionService.DeleteQuestionAsync(id);
        return Ok(result);
    }
}
