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
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public ActionResult<List<Location>> Get() =>
            _locationService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(string id)
        {
            var student = await _locationService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Location location)
        {
            await _locationService.CreateAsync(location);
            return Ok(location);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Location location)
        {
            var queriedLocation = await _locationService.GetByIdAsync(id);
            if (queriedLocation == null)
            {
                return NotFound();
            }
            await _locationService.UpdateAsync(id, location);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            await _locationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
