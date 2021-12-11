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
    public class PrisonRankController : ControllerBase
    {
        private readonly PrisonRankService _prisonRankService;

        public PrisonRankController(PrisonRankService prisonRankService)
        {
            _prisonRankService = prisonRankService;
        }

        [HttpGet]
        public ActionResult<List<PrisonRank>> Get() =>
            _prisonRankService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonRank>> GetById(string id)
        {
            var student = await _prisonRankService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrisonRank prisonRank)
        {
            await _prisonRankService.CreateAsync(prisonRank);
            return Ok(prisonRank);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, PrisonRank prisonRank)
        {
            var queriedPrisonRank = await _prisonRankService.GetByIdAsync(id);
            if (queriedPrisonRank == null)
            {
                return NotFound();
            }
            await _prisonRankService.UpdateAsync(id, prisonRank);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var prisonRank = await _prisonRankService.GetByIdAsync(id);
            if (prisonRank == null)
            {
                return NotFound();
            }
            await _prisonRankService.DeleteAsync(id);
            return NoContent();
        }
    }
}
