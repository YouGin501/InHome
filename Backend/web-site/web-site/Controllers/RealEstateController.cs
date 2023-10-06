using System;
using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Contracts;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RealEstate>>> GetAllRealEstates(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyNewBuildings,
            bool? isOnlyLiked,
            int? userId
        )
        {
            try
            {
                var realEstates = await _realEstateService.GetAllRealEstates(
                    startDate,
                    endDate,
                    numberOfRecords,
                    isOnlyNewBuildings,
                    isOnlyLiked,
                    userId
                );
                return Ok(realEstates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RealEstate>> GetRealEstate([FromRoute] int id)
        {
            try
            {
                var realEstate = await _realEstateService.GetRealEstateById(id);

                if (realEstate == null)
                {
                    return NotFound();
                }

                return realEstate;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RealEstate>> PostRealEstate(
            [FromBody] RealEstate realEstateModel
        )
        {
            try
            {
                return await _realEstateService.AddRealEstate(realEstateModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RealEstate>> PutRealEstate(
            [FromRoute] int id,
            [FromBody] RealEstate realEstateModel
        )
        {
            if (id != realEstateModel.Id)
            {
                return BadRequest();
            }

            try
            {
                return await _realEstateService.UpdateRealEstate(realEstateModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate([FromRoute] int id)
        {
            try
            {
                await _realEstateService.DeleteRealEstate(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
