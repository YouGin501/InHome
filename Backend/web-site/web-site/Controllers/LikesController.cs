using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly LikeService _likeService;

        public LikesController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Like>>> GetAllLikes(int userId)
        {
            var likes = await _likeService.GetAllLikes(userId);
            return Ok(likes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike([FromRoute] int id)
        {
            var like = await _likeService.GetLikeById(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        [HttpPost]
        public async Task<ActionResult<Like>> PostLike([FromBody] Like likeModel)
        {
            await _likeService.AddLike(likeModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLike([FromRoute] int id, [FromBody] Like likeModel)
        {
            if (id != likeModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _likeService.UpdateLike(likeModel);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike([FromRoute] int id)
        {
            try
            {
                await _likeService.DeleteLike(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
