using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Contracts;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        private readonly IDesignService _designService;

        public DesignController(IDesignService designService)
        {
            _designService = designService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Design>>> GetAllDesigns(
            string? startDate,
            string? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        )
        {
            try
            {
                DateTime? start = startDate != null ? DateTime.Parse(startDate) : null;
                DateTime? end = endDate != null ? DateTime.Parse(endDate) : null;
                var designs = await _designService.GetAllDesigns(
                    start,
                    end,
                    numberOfRecords,
                    isOnlyLiked,
                    userId
                );
                return Ok(designs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Design>> GetDesign([FromRoute] int id)
        {
            try
            {
                var design = await _designService.GetDesignById(id);

                if (design == null)
                {
                    return NotFound();
                }

                return design;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Design>> PostDesign([FromBody] Design designModel)
        {
            try
            {
                return await _designService.AddDesign(designModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Design>> PutDesign(
            [FromRoute] int id,
            [FromBody] Design designModel
        )
        {
            if (id != designModel.Id)
            {
                return BadRequest();
            }

            try
            {
                return await _designService.UpdateDesign(designModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesign([FromRoute] int id)
        {
            try
            {
                await _designService.DeleteDesign(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
