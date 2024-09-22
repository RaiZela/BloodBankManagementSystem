using BloodBankManagementSystem.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExaminationsController : ControllerBase
{
    private readonly IExaminationService _examinationService;

    public ExaminationsController(IExaminationService examinationService)
    {
        _examinationService = examinationService;
    }




    #region Examinations 

    [HttpPost]
    public async Task<IActionResult> CreateExamination([FromBody] ExaminationViewModel examination)
    {
        var response = await _examinationService.CreateExaminationAsync(examination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExaminationById(int id)
    {
        var response = await _examinationService.GetExaminationByIdAsync(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExaminations()
    {
        var response = await _examinationService.GetAllExaminationsAsync();
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExamination([FromBody] ExaminationViewModel examination)
    {
        var response = await _examinationService.UpdateExaminationAsync(examination);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExamination(int id)
    {
        var response = await _examinationService.DeleteExaminationAsync(id);
        return Ok(response);
    }

    #endregion Examinations

    #region ReferenceVales
    [HttpPost("reference")]
    public async Task<IActionResult> AddReferenceValue([FromBody] ReferenceValueViewModel referenceValue)
    {
        var response = await _examinationService.AddReferenceValueAsync(referenceValue);
        return Ok(response);
    }

    [HttpGet("reference/{id}")]
    public async Task<IActionResult> GetReferenceValueById(int id)
    {
        var response = await _examinationService.GetReferenceValueByIdAsync(id);
        return Ok(response);
    }

    [HttpGet("reference")]
    public async Task<IActionResult> GetAllReferenceValues()
    {
        var response = await _examinationService.GetAllReferenceValuesAsync();
        return Ok(response);
    }

    [HttpPut("reference")]
    public async Task<IActionResult> UpdateReferenceValue([FromBody] ReferenceValueViewModel referenceValue)
    {
        var response = await _examinationService.UpdateReferenceValueAsync(referenceValue);
        return Ok(response);
    }

    [HttpDelete("reference/{id}")]
    public async Task<IActionResult> DeleteReferenceValue(int id)
    {
        var response = await _examinationService.DeleteReferenceValueAsync(id);
        return Ok(response);
    }
    #endregion


}
