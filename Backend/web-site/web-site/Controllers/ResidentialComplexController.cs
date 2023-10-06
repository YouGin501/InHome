using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Contracts;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialComplexController : ControllerBase
    {
        private readonly IResidentialComplexService _residentialComplexService;

        public ResidentialComplexController(IResidentialComplexService residentialComplexService)
        {
            _residentialComplexService = residentialComplexService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllResidentialComplexes(int? userId)
        {
            var complexes = await _residentialComplexService.GetAllResidentialComplexes(userId);
            return Ok(complexes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetResidentialComplex([FromRoute] int id)
        {
            var complex = await _residentialComplexService.GetResidentialComplexById(id);
            if (complex == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ResidentialComplex>> PostResidentialComplex(
            [FromBody] ResidentialComplex complex
        )
        {
            try
            {
                return await _residentialComplexService.AddResidentialComplex(complex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResidentialComplex>> PutResidentialComplex(
            [FromRoute] int id,
            [FromRoute] ResidentialComplex complex
        )
        {
            if (id != complex.Id)
            {
                return BadRequest();
            }
            try
            {
                return await _residentialComplexService.UpdateResidentialComplex(complex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidentialComplex([FromRoute] int id)
        {
            try
            {
                await _residentialComplexService.DeleteResidentialComplex(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
