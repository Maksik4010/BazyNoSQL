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
    public class PrisonerController : ControllerBase
    {
        private readonly PrisonerService _prisonerService;

        public PrisonerController(PrisonerService prisonerService)
        {
            _prisonerService = prisonerService;
        }

        [HttpGet]
        public ActionResult<List<Prisoner>> Get() =>
            _prisonerService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Prisoner>> GetById(string id)
        {
            var student = await _prisonerService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Prisoner prisoner)
        {
            await _prisonerService.CreateAsync(prisoner);
            return Ok(prisoner);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Prisoner prisoner)
        {
            var queriedPrisoner = await _prisonerService.GetByIdAsync(id);
            if (queriedPrisoner == null)
            {
                return NotFound();
            }
            await _prisonerService.UpdateAsync(id, prisoner);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var prisoner = await _prisonerService.GetByIdAsync(id);
            if (prisoner == null)
            {
                return NotFound();
            }
            await _prisonerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
