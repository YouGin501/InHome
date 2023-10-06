using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Contracts;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rent>>> GetAllRents(
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
                var rents = await _rentService.GetAllRents(
                    start,
                    end,
                    numberOfRecords,
                    isOnlyLiked,
                    userId
                );
                return Ok(rents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRent([FromRoute] int id)
        {
            try
            {
                var rent = await _rentService.GetRentById(id);

                if (rent == null)
                {
                    return NotFound();
                }

                return rent;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Rent>> PostRent([FromBody] Rent rent)
        {
            try
            {
                return await _rentService.AddRent(rent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Rent>> PutRent([FromRoute] int id, [FromBody] Rent rentModel)
        {
            if (id != rentModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _rentService.UpdateRent(rentModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent([FromRoute] int id)
        {
            try
            {
                await _rentService.DeleteRent(id);
                return Ok();
            }
             catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
