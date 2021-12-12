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
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<List<Application>> Get() =>
            _applicationService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetById(string id)
        {
            var student = await _applicationService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Application application)
        {
            await _applicationService.CreateAsync(application);
            return Ok(application);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Application application)
        {
            var queriedApplication = await _applicationService.GetByIdAsync(id);
            if (queriedApplication == null)
            {
                return NotFound();
            }
            await _applicationService.UpdateAsync(id, application);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var application = await _applicationService.GetByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            await _applicationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
