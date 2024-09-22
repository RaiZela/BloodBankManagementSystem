using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
using Shared;
using BloodBankManagementSystem.BLL.Services.Settings;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspensionReasonController : ControllerBase
    {
        private readonly ISuspensionReasonService _service;
        public SuspensionReasonController(ISuspensionReasonService service)
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
        public async Task<IActionResult> Create([FromBody] SuspensionReasonViewModel value)
        {
            var result = await _service.Add(value);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SuspensionReasonViewModel value)
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
}
