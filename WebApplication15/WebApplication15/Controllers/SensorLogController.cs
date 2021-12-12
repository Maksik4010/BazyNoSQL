using WebApplication15.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Services;

namespace WebApplication15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorLogController : ControllerBase
    {
        private readonly SensorLogService _sensorLogService;

        public SensorLogController(SensorLogService sensorLogService)
        {
            _sensorLogService = sensorLogService;
        }

        [HttpGet]
        public ActionResult<List<SensorLog>> Get() =>
            _sensorLogService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<SensorLog>> GetById(string id)
        {
            var student = await _sensorLogService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SensorLog sensorLog)
        {
            await _sensorLogService.CreateAsync(sensorLog);
            return Ok(sensorLog);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SensorLog sensorLog)
        {
            var queriedSensorLog = await _sensorLogService.GetByIdAsync(id);
            if (queriedSensorLog == null)
            {
                return NotFound();
            }
            await _sensorLogService.UpdateAsync(id, sensorLog);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sensorLog = await _sensorLogService.GetByIdAsync(id);
            if (sensorLog == null)
            {
                return NotFound();
            }
            await _sensorLogService.DeleteAsync(id);
            return NoContent();
        }
    }
}
