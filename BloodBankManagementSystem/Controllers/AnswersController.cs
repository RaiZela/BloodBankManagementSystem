using BloodBankManagementSystem.BLL.Services.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public AnswersController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] AnswerViewModel answer)
        {
            var result = await _questionService.CreateAnswerAsync(answer);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var result = await _questionService.GetAnswerByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswers()
        {
            var result = await _questionService.GetAllAnswersAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnswer([FromBody] AnswerViewModel answer)
        {
            var result = await _questionService.UpdateAnswerAsync(answer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var result = await _questionService.DeleteAnswerAsync(id);
            return Ok(result);
        }
    }
}
