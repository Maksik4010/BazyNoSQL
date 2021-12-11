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
    public class GuardController : ControllerBase
    {
        private readonly GuardService _guardService;

        public GuardController(GuardService guardService)
        {
            _guardService = guardService;
        }

        [HttpGet]
        public ActionResult<List<Guard>> Get() =>
            _guardService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Guard>> GetById(string id)
        {
            var student = await _guardService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guard guard)
        {
            await _guardService.CreateAsync(guard);
            return Ok(guard);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Guard guard)
        {
            var queriedGuard = await _guardService.GetByIdAsync(id);
            if (queriedGuard == null)
            {
                return NotFound();
            }
            await _guardService.UpdateAsync(id, guard);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var guard = await _guardService.GetByIdAsync(id);
            if (guard == null)
            {
                return NotFound();
            }
            await _guardService.DeleteAsync(id);
            return NoContent();
        }
    }
}
