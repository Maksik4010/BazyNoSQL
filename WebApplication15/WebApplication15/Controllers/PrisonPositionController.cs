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
    public class PrisonPsitionController : ControllerBase
    {
        private readonly PrisonPositionService _prisonPositionService;

        public PrisonPsitionController(PrisonPositionService prisonPositionService)
        {
            _prisonPositionService = prisonPositionService;
        }

        [HttpGet]
        public ActionResult<List<PrisonPosition>> Get() =>
            _prisonPositionService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonPosition>> GetById(string id)
        {
            var student = await _prisonPositionService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrisonPosition prisonPosition)
        {
            await _prisonPositionService.CreateAsync(prisonPosition);
            return Ok(prisonPosition);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, PrisonPosition prisonPosition)
        {
            var queriedPrisonPosition = await _prisonPositionService.GetByIdAsync(id);
            if (queriedPrisonPosition == null)
            {
                return NotFound();
            }
            await _prisonPositionService.UpdateAsync(id, prisonPosition);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var prisonPosition = await _prisonPositionService.GetByIdAsync(id);
            if (prisonPosition == null)
            {
                return NotFound();
            }
            await _prisonPositionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
