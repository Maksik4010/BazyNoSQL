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
    public class SensorController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public SensorController(SensorService sensorService)
        { 
            _sensorService = sensorService;
        }

        [HttpGet]
        public ActionResult<List<Sensor>> Get() =>
            _sensorService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetById(string id)
        {
            var student = await _sensorService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sensor senosr)
        {
            await _sensorService.CreateAsync(senosr);
            return Ok(senosr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Sensor senosr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var queriedSensor = await _sensorService.GetByIdAsync(id);
            if (queriedSensor == null)
            {
                return NotFound();
            }
            await _sensorService.UpdateAsync(id, senosr);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var senosr = await _sensorService.GetByIdAsync(id);
            if (senosr == null)
            {
                return NotFound();
            }
            await _sensorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
