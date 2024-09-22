using BloodBankManagementSystem.BLL.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
using Shared;

namespace BloodBankManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComponentStorageSystemController : ControllerBase
{
    private readonly IComponentStorageSystemService _service;
    public ComponentStorageSystemController(IComponentStorageSystemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _service.Get(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ComponentStorageSystemViewModel value)
    {
        var result = await _service.Add(value);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ComponentStorageSystemViewModel value)
    {
        var result = await _service.Update(value);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id);
        return Ok(result);
    }
}

