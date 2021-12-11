using ConsoleApp2.models;
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
    public class SensorTypeController : ControllerBase
    {
        private readonly SensorTypeService _sensorTypeService;

        public SensorTypeController(SensorTypeService sensorTypeService)
        {
            _sensorTypeService = sensorTypeService;
        }

        [HttpGet]
        public ActionResult<List<SensorType>> Get() =>
            _sensorTypeService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<SensorType>> GetById(string id)
        {
            var student = await _sensorTypeService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SensorType sensorType)
        {
            await _sensorTypeService.CreateAsync(sensorType);
            return Ok(sensorType);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SensorType sensorType)
        {
            var queriedSensorType = await _sensorTypeService.GetByIdAsync(id);
            if (queriedSensorType == null)
            {
                return NotFound();
            }
            await _sensorTypeService.UpdateAsync(id, sensorType);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sensorType = await _sensorTypeService.GetByIdAsync(id);
            if (sensorType == null)
            {
                return NotFound();
            }
            await _sensorTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
