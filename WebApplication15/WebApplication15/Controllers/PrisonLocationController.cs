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
    public class PrisonLocationController : ControllerBase
    {
        private readonly PrisonLocationService _prisonLocationService;

        public PrisonLocationController(PrisonLocationService prisonLocationService)
        {
            _prisonLocationService = prisonLocationService;
        }

        [HttpGet]
        public ActionResult<List<PrisonLocation>> Get() =>
            _prisonLocationService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonLocation>> GetById(string id)
        {
            var student = await _prisonLocationService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrisonLocation prisonLocation)
        {
            await _prisonLocationService.CreateAsync(prisonLocation);
            return Ok(prisonLocation);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, PrisonLocation prisonLocation)
        {
            var queriedPrisonLocation = await _prisonLocationService.GetByIdAsync(id);
            if (queriedPrisonLocation == null)
            {
                return NotFound();
            }
            await _prisonLocationService.UpdateAsync(id, prisonLocation);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var prisonLocation = await _prisonLocationService.GetByIdAsync(id);
            if (prisonLocation == null)
            {
                return NotFound();
            }
            await _prisonLocationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
