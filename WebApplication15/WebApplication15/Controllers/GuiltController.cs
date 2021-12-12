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
    public class GuiltController : ControllerBase
    {
        private readonly GuiltService _guiltService;

        public GuiltController(GuiltService guiltService)
        {
            _guiltService = guiltService;
        }

        [HttpGet]
        public ActionResult<List<Guilt>> Get() =>
            _guiltService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Guilt>> GetById(string id)
        {
            var student = await _guiltService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guilt guilt)
        {
            await _guiltService.CreateAsync(guilt);
            return Ok(guilt);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Guilt guilt)
        {
            var queriedGuilt = await _guiltService.GetByIdAsync(id);
            if (queriedGuilt == null)
            {
                return NotFound();
            }
            await _guiltService.UpdateAsync(id, guilt);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var guilt = await _guiltService.GetByIdAsync(id);
            if (guilt == null)
            {
                return NotFound();
            }
            await _guiltService.DeleteAsync(id);
            return NoContent();
        }
    }
}
