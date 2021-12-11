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
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public ActionResult<List<Schedule>> Get() =>
            _scheduleService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetById(string id)
        {
            var student = await _scheduleService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Schedule schedule)
        {
            await _scheduleService.CreateAsync(schedule);
            return Ok(schedule);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Schedule schedule)
        {
            var queriedSchedule = await _scheduleService.GetByIdAsync(id);
            if (queriedSchedule == null)
            {
                return NotFound();
            }
            await _scheduleService.UpdateAsync(id, schedule);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            await _scheduleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
