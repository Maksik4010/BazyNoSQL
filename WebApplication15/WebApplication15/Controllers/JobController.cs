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
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public ActionResult<List<Job>> Get() =>
            _jobService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetById(string id)
        {
            var student = await _jobService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Job job)
        {
            await _jobService.CreateAsync(job);
            return Ok(job);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Job job)
        {
            var queriedJob = await _jobService.GetByIdAsync(id);
            if (queriedJob == null)
            {
                return NotFound();
            }
            await _jobService.UpdateAsync(id, job);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var job = await _jobService.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            await _jobService.DeleteAsync(id);
            return NoContent();
        }
    }
}
