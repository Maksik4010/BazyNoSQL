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
    public class PrisonerJobController : ControllerBase
    {
        private readonly PrisonerJobService _prisonerJobService;

        public PrisonerJobController(PrisonerJobService prisonerJobService)
        {
            _prisonerJobService = prisonerJobService;
        }

        [HttpGet]
        public ActionResult<List<PrisonerJob>> Get() =>
            _prisonerJobService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonerJob>> GetById(string id)
        {
            var student = await _prisonerJobService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrisonerJob prisonerJob)
        {
            await _prisonerJobService.CreateAsync(prisonerJob);
            return Ok(prisonerJob);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, PrisonerJob prisonerJob)
        {
            var queriedPrisonerJob = await _prisonerJobService.GetByIdAsync(id);
            if (queriedPrisonerJob == null)
            {
                return NotFound();
            }
            await _prisonerJobService.UpdateAsync(id, prisonerJob);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var prisonerJob = await _prisonerJobService.GetByIdAsync(id);
            if (prisonerJob == null)
            {
                return NotFound();
            }
            await _prisonerJobService.DeleteAsync(id);
            return NoContent();
        }
    }
}
