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
    public class ApplicationTypeController : ControllerBase
    {
        private readonly ApplicationTypeService _applicationTypeService;

        public ApplicationTypeController(ApplicationTypeService applicationTypeService)
        {
            _applicationTypeService = applicationTypeService;
        }

        [HttpGet]
        public ActionResult<List<ApplicationType>> Get() =>
            _applicationTypeService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationType>> GetById(string id)
        {
            var student = await _applicationTypeService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationType applicationType)
        {
            await _applicationTypeService.CreateAsync(applicationType);
            return Ok(applicationType);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ApplicationType applicationType)
        {
            var queriedApplicationType = await _applicationTypeService.GetByIdAsync(id);
            if (queriedApplicationType == null)
            {
                return NotFound();
            }
            await _applicationTypeService.UpdateAsync(id, applicationType);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var applicationType = await _applicationTypeService.GetByIdAsync(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            await _applicationTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
