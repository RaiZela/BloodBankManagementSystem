using BloodBankManagementSystem.BLL.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
using Shared;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagTypeController : ControllerBase
    {
        private readonly IBagTypeService _service;
        public BagTypeController(IBagTypeService service)
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
        public async Task<IActionResult> Create([FromBody] BagTypeViewModel value)
        {
            var result = await _service.Add(value);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BagTypeViewModel value)
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

