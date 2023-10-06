using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationsController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation([FromRoute] int id)
        {
            var location = await _locationService.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpPost]
        public async Task<ActionResult> PostLocation([FromBody] Location locationModel)
        {
            await _locationService.AddLocation(locationModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation([FromRoute] int id, [FromBody] Location locationModel)
        {
            if (id != locationModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _locationService.UpdateLocation(locationModel);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        {
            try
            {
                await _locationService.DeleteLocation(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
